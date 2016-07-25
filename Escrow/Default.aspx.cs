using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Escrow.Models;
using System.Xml.Linq;
using System.Xml;

namespace Escrow
{
    public partial class _Default : Page
    {

        //Function to create software POCO object
        #region
        public Software CreateSoftwareObject(string software_Name, string software_Version, string software_Description)
        {
            Software Software_1 = new Software { Software_Name = software_Name, Software_Version = software_Version, Software_Description = software_Description, Software_Owner_Payment_Percentage = "", Software_Beneficiary_Payment_Percentage = "" };
            return Software_1;
        }

        //Overload function to create software object with payment percentages
        public Software CreateSoftwareObject(string software_Name, string software_Version, string software_Description, string software_Owner_Payment_Percentage, string software_Beneficiary_Payment_Percentage)
        {
            //How you create an object instance from a model
            Software Software_1 = new Software { Software_Name = software_Name, Software_Version = software_Version, Software_Description = software_Description, Software_Owner_Payment_Percentage = software_Owner_Payment_Percentage, Software_Beneficiary_Payment_Percentage = software_Beneficiary_Payment_Percentage };
            return Software_1;
        }
        #endregion

        //Function to create party POCO object
        #region
        public Party CreatePartyObject(string role, string entity_Type, string fullname, bool trading_bool,  string trading_name, bool division_bool, string division_name, string party_registration_number, string title, string party_contact_fullname, string fax, string telephone, string email, string physical, string postal,  bool postal_bool)
        {
            string trading_option = "No";
            string division_option = "No";
            string postal_option = "No";
            if (trading_bool == true)
            {
                trading_option = "Yes";
            }
            if (division_bool == true)
            {
                division_option = "Yes";
            }
            if (postal_bool == true)
            {
                postal_option = "Yes";
            }
            Party Party_1 = new Party { Party_Role = role, Party_Entity_Type = entity_Type, Party_Fullname = fullname, Party_Trading_Option = trading_option, Party_Trading_Name = trading_name, Party_Division_Option = division_option, Party_Division_Name = division_name, Party_Registration_Number = party_registration_number, Party_Title = title, Party_Contact_Fullname = party_contact_fullname, Party_Email = email, Party_Fax = fax, Party_Telephone = telephone, Party_Physical_Address = physical, Party_Physical_Same_A_Postal_Option = postal_option, Party_Postal_Address = postal };
            return Party_1;

        }
        #endregion

        //Function to create Agreement POCO object
        #region
        public Agreement CreateAgreementObject(string agreement_type, bool agreement_main_agreement_option, string agreement_main_agreement_name, bool agreement_effective_date_option, string agreement_effective_date, bool agreement_release_event_ceases_to_trade, bool agreement_release_event_transfer_without_agreeing, bool agreement_release_event_disposal_assets, bool agreement_release_event_change_control, bool agreement_release_event_transfer_to_competitor, bool agreement_release_event_breach_escrow, bool agreement_release_event_financial_distress, bool agreement_release_event_recieve_notice, bool agreement_release_event_owner_maintenance, bool agreement_release_other_option, string agreement_release_event_other)
        {
            
            string main_agreement_option = "No";// agreement_main_agreement_option
            if (agreement_main_agreement_option == true)
            {
                main_agreement_option = "Yes";
            }
            string effective_date_option = "No";// agreement_effective_date_option
            if (agreement_effective_date_option == true)
            {
                effective_date_option = "Yes";
            }
            string event_ceases_to_trade = "No";// agreement_release_event_ceases_to_trade
            if (agreement_release_event_ceases_to_trade == true)
            {
                event_ceases_to_trade = "Yes";
            }
            string event_transfer_without_agreeing = "No";// agreement_release_event_transfer_without_agreeing
            if (agreement_release_event_transfer_without_agreeing == true)
            {
                event_transfer_without_agreeing = "Yes";
            }
            string event_disposal_assets = "No";// agreement_release_event_disposal_assets
            if (agreement_release_event_disposal_assets == true)
            {
                event_disposal_assets = "Yes";
            }
            string event_change_control = "No";// agreement_release_event_change_control
            if (agreement_release_event_change_control == true)
            {
                event_change_control = "Yes";
            }
            string event_transfer_to_competitor = "No";// agreement_release_event_transfer_to_competitor
            if (agreement_release_event_transfer_to_competitor == true)
            {
                event_transfer_to_competitor = "Yes";
            }
            string event_breach_escrow = "No";// agreement_release_event_breach_escrow
            if (agreement_release_event_breach_escrow == true)
            {
                event_breach_escrow = "Yes";
            }
            string event_financial_distress = "No";// agreement_release_event_financial_distress
            if (agreement_release_event_financial_distress == true)
            {
                event_financial_distress = "Yes";
            }
            string event_recieve_notice = "No";// agreement_release_event_recieve_notice
            if (agreement_release_event_recieve_notice == true)
            {
                event_recieve_notice = "Yes";
            }
            string event_owner_maintenance = "No";// agreement_release_event_owner_maintenance
            if (agreement_release_event_owner_maintenance == true)
            {
                event_owner_maintenance = "Yes";
            }
            string event_release_other_option = "No";// agreement_release_other_option
            if (agreement_release_other_option == true)
            {
                event_release_other_option = "Yes";
            }

            

            Agreement Agreement_1 = new Agreement { Agreement_Type = agreement_type, Agreement_Main_Agreement_Option = main_agreement_option, Agreement_Main_Agreement_Name = agreement_main_agreement_name, Agreement_Effective_Date_Option = effective_date_option, Agreement_Effective_Date = agreement_effective_date, Agreement_Release_Event_Ceases_To_Trade = event_ceases_to_trade, Agreement_Release_Event_Transfer_Without_Agreeing = event_transfer_without_agreeing, Agreement_Release_Event_Disposal_Assets = event_disposal_assets, Agreement_Release_Event_Change_Control = event_change_control, Agreement_Release_Event_Transfer_To_Competitor = event_transfer_to_competitor, Agreement_Release_Event_Breach_Escrow = event_breach_escrow, Agreement_Release_Event_Financial_Distress = event_financial_distress, Agreement_Release_Event_Recieve_Notice = event_recieve_notice, Agreement_Release_Event_Owner_Maintenance = event_owner_maintenance, Agreement_Release_Other_Option = event_release_other_option, Agreement_Release_Event_Other = agreement_release_event_other };
            return Agreement_1;

        }
        #endregion

        //Function to retrieve dowload link for the assembled document
        #region
        public void Get_Assembled_Document(string XML_string_Resposne)
        {
            //Code to convert the string response to XML so we can find the download link using XML functions
            //Code below just loads the response string to XML var then we just search for the DowloadLink node then BOOM its there (*_*)
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(XML_string_Resposne);
            XmlNodeList nodeList = xmldoc.GetElementsByTagName("DownloadLink");
            string Download_Link = string.Empty;
            foreach (XmlNode node in nodeList)
            {
                Download_Link = node.InnerText;
                //txt below is just for test purposes so remove in final 
                //txtXML_Input.Text = Short_Fall;
                Response.Redirect(Download_Link);
            }
        }
        #endregion




        public string CreateInterviewXML(Agreement Agreement_1, Software Software_1, Party Party_1, Party Party_2, Party Party_3)
        {
            //Escrow agreement details 'main' parent node
            #region
            XElement xml = new XElement("EscrowAgreement",
                new XElement("Agreement_Type",
                    Agreement_1.Agreement_Type),
                new XElement("Main_Agreement_Option",
                    Agreement_1.Agreement_Main_Agreement_Option),
                new XElement("Main_Agreement_Name",
                    Agreement_1.Agreement_Main_Agreement_Name),
                new XElement("Escrow_Main_Agreement_Effective_Date",
                    Agreement_1.Agreement_Effective_Date),
                new XElement("Main_Agreement_Ceases_To_Trade_Option",
                    Agreement_1.Agreement_Release_Event_Ceases_To_Trade),
                new XElement("Main_Agreement_Transfer_Without_Beneficiary_Agreement_Option",
                    Agreement_1.Agreement_Release_Event_Transfer_Without_Agreeing),
                 //dsfdsfsdf
                 new XElement("Main_Agreement_Release_Of_Assets_Portion_Option",
                    Agreement_1.Agreement_Release_Event_Disposal_Assets),
                new XElement("Main_Agreement_Change_Control_Option",
                    Agreement_1.Agreement_Release_Event_Change_Control),
                new XElement("Main_Agreement_Title_Transfer_Rights_Option",
                    Agreement_1.Agreement_Release_Event_Transfer_Without_Agreeing),
                new XElement("Main_Agreement_Escrow_Breach",
                    Agreement_1.Agreement_Release_Event_Breach_Escrow),
                new XElement("Main_Agreement_Financial_Distress",
                    Agreement_1.Agreement_Release_Event_Financial_Distress),
                new XElement("Main_Agreement_Receives_Notice_To_Commence_Business",
                    Agreement_1.Agreement_Release_Event_Recieve_Notice),
                new XElement("Main_Agreement_Maintenance_Option",
                    Agreement_1.Agreement_Release_Event_Owner_Maintenance),
                new XElement("Main_Agreement_Other_Release_Event_Option",
                    Agreement_1.Agreement_Release_Other_Option),
                new XElement("Main_Agreement_Other_Release_Event",
                    Agreement_1.Agreement_Release_Event_Other),
                new XElement("Main_Agreement_Other_Name",
                    "Main_Agreement_Other_Name Nonsense FIX IT"),
                new XElement("Escrow_Agreement_Effective_Date_Option",
                    Agreement_1.Agreement_Effective_Date_Option), 
                new XElement("_MainHeadingPlaceHolder"),
#endregion

                //New Party Parent node
            #region
                new XElement("Party",
                new XElement("Entity_Type",
                    Party_1.Party_Entity_Type),
                new XElement("Name",
                    Party_1.Party_Fullname),
                new XElement("Acting_Through_Division_Question",
                    Party_1.Party_Division_Option),
                new XElement("Division_Name",
                    Party_1.Party_Division_Name),
                new XElement("Trading_As_Question",
                    Party_1.Party_Trading_Option),
                new XElement("Trading_As_Name",
                    Party_1.Party_Trading_Name),
                new XElement("Role",
                    Party_1.Party_Role),
                new XElement("SA_Registration_Number",
                    Party_1.Party_Registration_Number),
                new XElement("Physical_Address_Contact",
                    Party_1.Party_Physical_Address),
                new XElement("Physical_Same_As_Postal_Option",
                    Party_1.Party_Physical_Same_A_Postal_Option),
                new XElement("Postal_Address_Contact",
                    Party_1.Party_Postal_Address),
                new XElement("Telephone_Contact",
                    Party_1.Party_Telephone),
                new XElement("Fax_Contact",
                    Party_1.Party_Fax),
                new XElement("Fullname_Contact",
                    Party_1.Party_Contact_Fullname),
                new XElement("Email_Contact",
                    Party_1.Party_Email),
                new XElement("Country",
                    "ADD A COUNTRY FIELD IN PARTY"),
                new XElement("Identity_Number",
                    Party_1.Party_Registration_Number),
                new XElement("Title",
                    Party_1.Party_Title)),
#endregion

                //New Party Parent node
            #region
                new XElement("Party",
                new XElement("Entity_Type",
                    Party_2.Party_Entity_Type),
                new XElement("Name",
                    Party_2.Party_Fullname),
                new XElement("Acting_Through_Division_Question",
                    Party_2.Party_Division_Option),
                new XElement("Division_Name",
                    Party_2.Party_Division_Name),
                new XElement("Trading_As_Question",
                    Party_2.Party_Trading_Option),
                new XElement("Trading_As_Name",
                    Party_2.Party_Trading_Name),
                new XElement("Role",
                    Party_2.Party_Role),
                new XElement("SA_Registration_Number",
                    Party_2.Party_Registration_Number),
                new XElement("Physical_Address_Contact",
                    Party_2.Party_Physical_Address),
                new XElement("Physical_Same_As_Postal_Option",
                    Party_2.Party_Physical_Same_A_Postal_Option),
                new XElement("Postal_Address_Contact",
                    Party_2.Party_Postal_Address),
                new XElement("Telephone_Contact",
                    Party_2.Party_Telephone),
                new XElement("Fax_Contact",
                    Party_2.Party_Fax),
                new XElement("Fullname_Contact",
                    Party_2.Party_Contact_Fullname),
                new XElement("Email_Contact",
                    Party_2.Party_Email),
                new XElement("Country",
                    "ADD A COUNTRY FIELD IN PARTY"),
                new XElement("Identity_Number",
                    Party_2.Party_Registration_Number),
                new XElement("Title",
                    Party_2.Party_Title)),
            #endregion

                //New Software Parent node
            #region
                new XElement("Software",
                new XElement("Name_Of_Software_Component",
                    Software_1.Software_Name),
                new XElement("Software_Module_Version_Number",
                    Software_1.Software_Version),
                new XElement("Description_Of_Software_Component",
                    Software_1.Software_Description),
                new XElement("Software_Owner_Payment_Percentage",
                    Software_1.Software_Owner_Payment_Percentage),
                new XElement("Software_Beneficiary_Payment_Percentage",
                    Software_1.Software_Beneficiary_Payment_Percentage))
            #endregion
            );
            return xml.ToString();

        }

        //Function to asseble the Escrow agreement
        public void CreateEscrow(Agreement Chosen_Agreement, Party Party_1, Party Party_2, Party Party_3, Software Software_1)
        {
            ////Below is the XML string in the format for the specific interview, change the child nodes to match the interview DataElements 
            //string xml = "<EscrowAgreement><Deposit_Software_Owner>" "+ Software_Owner +" "</Deposit_Software_Owner><Deposit_Beneficiary_Contact>" "+ txtDeposit_Beneficiary + ""</Deposit_Beneficiary_Contact><Deposit_Account_Number>" + Deposit_Account_Number + "</Deposit_Account_Number><Deposit_Software_Date>" + Deposit_Date + "</Deposit_Software_Date><Deposit_Software_Method>" + Deposit_Method + "</Deposit_Software_Method><Deposit_Description>" + Software_Description + "</Deposit_Description></ChattanDepositConfirmationv22015>";
            ////Below is the URL for the XpressDox API function that allows you to fill a template with data using taken from the webpage form
            //string url = "https://server.xpressdox.com/Cloud/IntegrationServices/ThirdPartyService.svc/FillTemplateByTemplateID?authenticationTicket=ecaa3551-79a1-4810-98c0-d4ce3a4d01ea&templateIdentifier=7faa0c5e-bd32-433d-b410-839fd2d7e55a";
            //HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            //byte[] requestBytes = System.Text.Encoding.ASCII.GetBytes(xml);
            //req.Method = "POST";
            //req.ContentType = "text/xml;charset=utf-8";
            //req.ContentLength = requestBytes.Length;
            //Stream requestStream = req.GetRequestStream();
            //requestStream.Write(requestBytes, 0, requestBytes.Length);
            //requestStream.Close();

            ////Code block below is to retrieve the response from the XpressDox API and get the download link for the assembled document
            //HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            //StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.Default);
            //string backstr = sr.ReadToEnd();
            //txtXML_Input.Text = backstr;
            //sr.Close();
            //res.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }

        protected void btnAssemble_Click(object sender, EventArgs e)
        {
            Agreement Assemble_Agreement_POCO = CreateAgreementObject(dplAgreement_Type.SelectedValue, cbxMain_Agreement_Option.Checked, txtMain_Agreement_Other.Text, cbxMain_Agreement_Effective_Date_Option.Checked, cldMain_Agreement_Effective_Date.SelectedDate.ToString(), cbxRelease_Ceases.Checked, cbxRelease_Transfer_Without_Agreeing.Checked, cbxRelease_Disposal.Checked, cbxRelease_Change_In_Control.Checked, cbxRelease_Transfer_To_Competitor.Checked, cbxRelease_Breach_Escrow.Checked, cbxRelease_Financial_Distress.Checked, cbxRelease_Receive_Notice.Checked, cbxRelease_Owner_Maintenance.Checked, cbxRelease_Other.Checked, txtRelease_Other.Text);
            Party Assemble_Party_POCO = CreatePartyObject(dplParty_Role.SelectedValue.ToString(), dplPartyEntity_Type.SelectedValue.ToString(), txtParty_Fullname.Text, cbxParty_Trading_Option.Checked, txtParty_Trading_Name.Text, cbxParty_Division_Option.Checked, txtParty_Division_Name.Text, txtParty_Registration_Number.Text, dplParty_Contact_Title.SelectedValue.ToString(), txtParty_Contact_Fullname.Text, txtParty_Fax.Text, txtParty_Telephone.Text, txtParty_Email.Text, txtParty_Physical_Address.Text, txtParty_Postal_Address.Text, cbxParty_Physical_Same_Postal.Checked);
            Software Assemble_Software_POCO = CreateSoftwareObject(txtSoftware_Name.Text, txtSoftware_Version.Text, txtSoftware_Description.Text);
            string XML_Request = CreateInterviewXML(Assemble_Agreement_POCO, Assemble_Software_POCO, Assemble_Party_POCO, Assemble_Party_POCO, Assemble_Party_POCO);
        }

        protected void btnAssemble_Click1(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                lblMessage.Text = "Your reservation has been processed.";
            }
        }
    }
}