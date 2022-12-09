using Microsoft.AspNetCore.Components.Forms;

namespace IFS.DB.WebApp.Helpers.FieldCssClassProviders;

public class CustomPaymentConfirmFieldClassProvider : FieldCssClassProvider
{
    public override string GetFieldCssClass(EditContext editContext,
        in FieldIdentifier fieldIdentifier)
    {
        if (editContext == null)
        {
            throw new ArgumentNullException(nameof(editContext));
        }

        bool isValid = !editContext.GetValidationMessages(fieldIdentifier).Any();

        return isValid ? "input--success" : "error";
    }
}
