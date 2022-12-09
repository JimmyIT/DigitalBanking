using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Customers.UpdateSSE
{
    public interface IUpdateSSECustomerHandler : IBaseHandler
    {
        Task<ActionResult<UpdateSSECustomerResponse>> DoActionAsync(UpdateSSECustomerRequest customer);
    }

    public class UpdateSSECustomerHandler : BaseHandler, IUpdateSSECustomerHandler
    {
        private readonly IUpdateSSECustomerValidator _Validator;
        private readonly ICustomerRepo _CustomerRepo;
        private readonly IUserProfileRepo _UserProfileRepo;

        public UpdateSSECustomerHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            IUpdateSSECustomerValidator validator,
            ICustomerRepo customerRepo,
            IUserProfileRepo userProfileRepo)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _CustomerRepo = customerRepo;
            _UserProfileRepo = userProfileRepo;
        }

        public async Task<ActionResult<UpdateSSECustomerResponse>> DoActionAsync(UpdateSSECustomerRequest customer)
        {
            ActionResult<UpdateSSECustomerResponse> result = new ActionResult<UpdateSSECustomerResponse>()
            {
                Result = new UpdateSSECustomerResponse() { LogonID = customer.LogonID }
            };

            //Validate Header
            ValidationResult valResult = _HeaderValidator.AddIdempotencyKey().Validate(Header);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Validate Content
            valResult = _Validator.Validate(customer);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Set data IBankCustomer
            IBankCustomer ibankCusEntity = await _CustomerRepo.GetByLogonId(customer.LogonID);
            ibankCusEntity.HasBeenUpgraded = customer.ResetKeyword.GetValueOrDefault(false) ? true : ibankCusEntity.HasBeenUpgraded;
            ibankCusEntity.Activated = customer.Activated ?? ibankCusEntity.Activated;
            ibankCusEntity.BulkReleaseTransactions = customer.BulkRelease ?? ibankCusEntity.BulkReleaseTransactions;
            ibankCusEntity.PaymentsInBulk = customer.BulkPayment ?? ibankCusEntity.PaymentsInBulk;
            ibankCusEntity.PaymentFileCollection = customer.UploadPaymentCollection ?? ibankCusEntity.PaymentFileCollection;
            ibankCusEntity.PaymentFileCurrency = !string.IsNullOrEmpty(customer.PaymentCurrency) ? customer.PaymentCurrency : string.Empty;
            ibankCusEntity.CanUploadPaymentFiles = customer.UploadPaymentFile ?? ibankCusEntity.CanUploadPaymentFiles;

            //Set data UserProfile
            IEnumerable<UserProfile> lstUser = await _UserProfileRepo.GetByLogonIdAsync(customer.LogonID);
            foreach (UserProfile user in lstUser)
            {
                user.Email = !string.IsNullOrEmpty(customer.Email) ? customer.Email : user.Email;
                user.MobilePhoneNumber = !string.IsNullOrEmpty(customer.Phone) ? customer.Phone : user.MobilePhoneNumber;
                user.MobilePhoneNumberIdd = !string.IsNullOrEmpty(customer.MobilePhoneNumberIDD) ? customer.Email : user.MobilePhoneNumberIdd;
                user.CanReleasePayments = customer.BulkRelease ?? user.CanReleasePayments;
                user.CanReleaseTransfers = customer.BulkRelease ?? user.CanReleaseTransfers;
                user.AuthorisePaymentsInBulk = customer.BulkPayment ?? user.AuthorisePaymentsInBulk;
                user.CanUploadPaymentFiles = customer.UploadPaymentFile ?? user.CanUploadPaymentFiles;
            }

            //Update SSE Customer
            IDbContextTransaction transaction = _CustomerRepo.DBContext.Database.BeginTransaction();

            try
            {
                await _CustomerRepo.UpdateAsync(ibankCusEntity, lstUser);

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }

            return result;
        }
    }
}
