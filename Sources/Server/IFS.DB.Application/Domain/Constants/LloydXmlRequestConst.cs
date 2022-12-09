using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Domain.Constants
{
    public struct LloydXmlRequestConst
    {
        public const string Sale = @"<?xml version='1.0' encoding='UTF-8'?>
                                        <SOAP-ENV:Envelope
                                           xmlns:SOAP-ENV='http://schemas.xmlsoap.org/soap/envelope/'>
                                            <SOAP-ENV:Header/>
                                            <SOAP-ENV:Body>
                                                <ns4:IPGApiOrderRequest
                                                    xmlns:ns4='http://ipg-online.com/ipgapi/schemas/ipgapi'
                                                    xmlns:ns2='http://ipg-online.com/ipgapi/schemas/v1'
                                                    xmlns:ns3='http://ipg-online.com/ipgapi/schemas/a1'>
                                                    <ns2:Transaction>
                                                        <ns2:CreditCardTxType>
                                                            <ns2:StoreId>{0}</ns2:StoreId>
                                                            <ns2:Type>sale</ns2:Type>
                                                        </ns2:CreditCardTxType>
                                                        <ns2:TransactionDetails>
                                                            <ns2:IpgTransactionId>{1}</ns2:IpgTransactionId>
                                                        </ns2:TransactionDetails>
                                                    </ns2:Transaction>
                                                </ns4:IPGApiOrderRequest>
                                            </SOAP-ENV:Body>
                                        </SOAP-ENV:Envelope>";

        public const string Return = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                                        " + "\n" +
                                        @"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">
                                        " + "\n" +
                                        @"    <SOAP-ENV:Header/>
                                        " + "\n" +
                                        @"    <SOAP-ENV:Body>
                                        " + "\n" +
                                        @"        <ipgapi:IPGApiOrderRequest
                                        " + "\n" +
                                        @"xmlns:v1=""http://ipg-online.com/ipgapi/schemas/v1""
                                        " + "\n" +
                                        @"xmlns:ipgapi=""http://ipg-online.com/ipgapi/schemas/ipgapi"">
                                        " + "\n" +
                                        @"            <v1:Transaction>
                                        " + "\n" +
                                        @"                <v1:CreditCardTxType>
                                        " + "\n" +
                                        @"                    <v1:StoreId>2220540407</v1:StoreId>
                                        " + "\n" +
                                        @"                    <v1:Type>credit</v1:Type>
                                        " + "\n" +
                                        @"                </v1:CreditCardTxType>
                                        " + "\n" +
                                        @"                <v1:CreditCardData>
                                        " + "\n" +
                                        @"                    <v1:CardCodeValue>{0}</v1:CardCodeValue>
                                        " + "\n" +
                                        @"                </v1:CreditCardData>
                                        " + "\n" +
                                        @"                <v1:Payment>
                                        " + "\n" +
                                        @"                    <v1:HostedDataID>{1}</v1:HostedDataID>
                                        " + "\n" +
                                        @"                    <v1:ChargeTotal>{2}</v1:ChargeTotal>
                                        " + "\n" +
                                        @"                    <v1:Currency>GBP</v1:Currency>
                                        " + "\n" +
                                        @"                </v1:Payment>
                                        " + "\n" +
                                        @"                <v1:TransactionDetails>
                                        " + "\n" +
                                        @"                    <v1:TransactionOrigin>ECI</v1:TransactionOrigin>
                                        " + "\n" +
                                        @"                </v1:TransactionDetails>
                                        " + "\n" +
                                        @"            </v1:Transaction>
                                        " + "\n" +
                                        @"        </ipgapi:IPGApiOrderRequest>
                                        " + "\n" +
                                        @"    </SOAP-ENV:Body>
                                        " + "\n" +
                                        @"</SOAP-ENV:Envelope>";

        public const string Display = @"<?xml version=""1.0"" encoding=""UTF-8"" ?>
                                        <SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"" >
                                            <SOAP-ENV:Header/>
                                            <SOAP-ENV:Body>
                                                <ns4:IPGApiActionRequest
                                                    xmlns:ns4=""http://ipg-online.com/ipgapi/schemas/ipgapi"" xmlns:ns2=""http://ipg-online.com/ipgapi/schemas/v1""
                                                    xmlns:ns3=""http://ipg-online.com/ipgapi/schemas/a1"">
                                                    <ns3:Action>
                                                        <ns3:StoreHostedData>
                                                            <ns3:DataStorageItem>
                                                                <ns3:Function>display</ns3:Function>
                                                                <ns3:HostedDataID>{0}</ns3:HostedDataID>
                                                            </ns3:DataStorageItem>
                                                        </ns3:StoreHostedData>
                                                    </ns3:Action>
                                                </ns4:IPGApiActionRequest>
                                            </SOAP-ENV:Body>
                                        </SOAP-ENV:Envelope>";

        public const string Delete = @"<?xml version=""1.0"" encoding=""UTF-8"" ?>
                                        " + "\n" +
                                        @"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"" >
                                        " + "\n" +
                                        @"    <SOAP-ENV:Header/>
                                        " + "\n" +
                                        @"    <SOAP-ENV:Body>
                                        " + "\n" +
                                        @"        <ns4:IPGApiActionRequest
                                        " + "\n" +
                                        @"xmlns:ns4=""http://ipg-online.com/ipgapi/schemas/ipgapi"" xmlns:ns2=""http://ipg-online.com/ipgapi/schemas/v1""
                                        " + "\n" +
                                        @"xmlns:ns3=""http://ipg-online.com/ipgapi/schemas/a1"">
                                        " + "\n" +
                                        @"            <ns3:Action>
                                        " + "\n" +
                                        @"                <ns3:StoreHostedData>
                                        " + "\n" +
                                        @"                    <ns3:DataStorageItem>
                                        " + "\n" +
                                        @"                        <ns3:Function>delete</ns3:Function>
                                        " + "\n" +
                                        @"                        <ns3:HostedDataID>{0}</ns3:HostedDataID>
                                        " + "\n" +
                                        @"                    </ns3:DataStorageItem>
                                        " + "\n" +
                                        @"                </ns3:StoreHostedData>
                                        " + "\n" +
                                        @"            </ns3:Action>
                                        " + "\n" +
                                        @"        </ns4:IPGApiActionRequest>
                                        " + "\n" +
                                        @"    </SOAP-ENV:Body>
                                        " + "\n" +
                                        @"</SOAP-ENV:Envelope>";
    }
}
