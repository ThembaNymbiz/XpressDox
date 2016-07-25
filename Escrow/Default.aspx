<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Escrow._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

 
<html>
<head>
    <title></title>
    <style type="text/css">
        .nav-tabs a, .nav-tabs a:hover, .nav-tabs a:focus
        {
            outline: 0;
        }

        input 
        {
    float:right;
    clear:both;
        }
    </style>
    <script>

     function changeLabeltext()

    {

     document.getElementById("lblFullname").value = "new text value";

    }

    </script>

    <%-- Script for changing the Entity type label --%>
    <script>
          $(document).ready(function ()
          {
              $('#dplEntity_Type').change(function ()
              {
                  var e = document.getElementById("dplEntity_Type");
                  var Chosen_Entity_Type = e.options[e.selectedIndex].text;
                  switch (Chosen_Entity_Type)
                  {
                      case "South African - Private Company":
                          $('#lblSelectedProductName').text('(Exclude Proprietary Limited or Pty Ltd)');
                          break;
                      case "South African - Public Company":
                          $('#lblSelectedProductName').text('(Exclude Limited or Ltd)');
                          break;
                      case "South African - South African - Close Corporation":
                          $('#lblSelectedProductName').text('(Exclude CC)');
                          break;
                      case "South African - Trust":
                          $('#lblSelectedProductName').text('(Exclude The Trustees for the time being eg only enter XYZ trust)');
                          break;
                      case "South African - Partnership":
                          $('#lblSelectedProductName').text('(Ask what partnership rules are for full name)');
                          break;
                      case "South African - Individual":
                          $('#lblSelectedProductName').text('Insert full name eg John Alexander Smith');
                          break;
                      case "Non South African - Individual":
                          $('#lblSelectedProductName').text('Test10');
                          break;
                      case "Non South African - Company, Trust or Partnership":
                          $('#lblSelectedProductName').text('Include entity description at the end, eg Inc, Pvt etc');
                          break;
                  }
                });
          });
          </script>
    <%-- End of script --%>
</head>
<body>
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript" src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js"></script>
    <form>
    <asp:ValidationSummary runat=server HeaderText="There were errors on the page:" />
    <div class="panel panel-default" style="width: 700px; padding: 10px; margin: 10px">
        <div id="Tabs" role="tabpanel">
            <!-- Nav tabs -->
            <ul class="nav nav-tabs" role="tablist">
                <li class="active"><a href="#personal" aria-controls="personal" role="tab" data-toggle="tab">
                    Agreement Details </a></li>
                <li><a href="#employment" aria-controls="employment" role="tab" data-toggle="tab">Party Details</a></li>
                <li><a href="#software" aria-controls="software" role="tab" data-toggle="tab">Software Details</a></li>
            </ul>
            <!-- Tab panes -->
            <div class="tab-content" style="padding-top: 20px">
                <div role="tabpanel" class="tab-pane active" id="personal">
                    <b>Agreement Details</b>
                    <p>
                        <asp:Label ID="Label1" runat="server" Text="What type of agreement is this?"></asp:Label>
                          <div style="text-align:right;">
                            <asp:RequiredFieldValidator runat=server ControlToValidate=dplAgreement_Type ErrorMessage="Agreement type must be selected" ID="Agreement_Type_ReqExpV" Display="Dynamic"> *
                            </asp:RequiredFieldValidator>
                            <asp:DropDownList ID="dplAgreement_Type" runat="server">
                            <asp:ListItem>Master Escrow Agreement</asp:ListItem>
                            <asp:ListItem>Tripartite Escrow Agreement</asp:ListItem>
                            </asp:DropDownList>
                          </div>
                    </p>
                    <p>
                        <asp:Label ID="Label2" runat="server" Text="Do you wish to mention the main agreement?"></asp:Label>
                        <asp:CheckBox ID="cbxMain_Agreement_Option" runat="server" />
                    </p>
                    <p>
                        <asp:Label ID="Label3" runat="server" Text="What is the name of the main agreement?"></asp:Label>
                        <asp:TextBox ID="txtMain_Agreement_Other" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        <asp:Label ID="Label5" runat="server" Text="Do you know the Effective Date of the Main Agreement?"></asp:Label>
                        <asp:CheckBox ID="cbxMain_Agreement_Effective_Date_Option" runat="server" />
                    </p>
                    <p>
                        Select the effective date of the Main Agreement:  
                        <div style="text-align:right;">
                        <asp:Calendar ID="cldMain_Agreement_Effective_Date" runat="server" Height="48px" CssClass="active right"></asp:Calendar>
                        </div>
                    </p>
                    <p><b>Additional release events: </b></p>
                    <p>Ceases something something IDK <asp:CheckBox ID="cbxRelease_Ceases" runat="server" Text="" TextAlign="Left" /></p>
                    <p>Transfer of Title to a third party where such third party does not agree to be bound by the provisions of this agreement <asp:CheckBox ID="cbxRelease_Transfer_Without_Agreeing" runat="server" TextAlign="Left"  Text="" /></p>
                    <p>Disposal of a material portion of assets <asp:CheckBox ID="cbxRelease_Disposal" runat="server" TextAlign="Left" Text="" /></p>
                    <p>Change in control <asp:CheckBox ID="cbxRelease_Change_In_Control" runat="server" TextAlign="Left" Text="" /></p>
                    <p>Transfer of Title to a competitor <asp:CheckBox ID="cbxRelease_Transfer_To_Competitor" runat="server" TextAlign="Left" Text="" /></p>
                    <p>Breach of Escrow <asp:CheckBox ID="cbxRelease_Breach_Escrow" runat="server" TextAlign="Left" Text="" /></p>
                    <p>Finacial distress IDK <asp:CheckBox ID="cbxRelease_Financial_Distress" runat="server" TextAlign="Left" Text="" /></p>
                    <p>Recieve notice to continue business IDK I'm guessing <asp:CheckBox ID="cbxRelease_Receive_Notice" runat="server" TextAlign="Left" Text="" />
                        
                    </p>
                    <p>Owner can not provide maintenance IDK again (-_-) <asp:CheckBox ID="cbxRelease_Owner_Maintenance" runat="server" TextAlign="Left" Text="" /></p>
                    <p>Would you like to add another release event? <asp:CheckBox ID="cbxRelease_Other" runat="server" TextAlign="Left" Text="" /></p>
                    <p><asp:TextBox ID="txtRelease_Other" runat="server" Text="Enter the release event:" Visible="False"></asp:TextBox></p>
                </div>
                <div role="tabpanel" class="tab-pane" id="employment">
                    <p><b>Party information</b></p>
                     <p>
                         <asp:Label ID="Label7" runat="server" Text="What is the Party Role?"></asp:Label>
                         <div style="text-align:right;">
                         <asp:RequiredFieldValidator runat=server ControlToValidate=dplParty_Role ErrorMessage="A Role for the party must be selected" ID="Party_Role_ReqExV" Display="Dynamic"> *
                         </asp:RequiredFieldValidator>
                         <asp:DropDownList ID="dplParty_Role" runat="server">
                             <asp:ListItem>Owner</asp:ListItem>
                             <asp:ListItem>Beneficiary</asp:ListItem>
                             <asp:ListItem>Escrow Agent</asp:ListItem>
                         </asp:DropDownList>
                         </div>
                     </p>
                     <p>
                         <asp:Label ID="Label8" runat="server" Text="What type of Entity is it?"></asp:Label>
                         <div style="text-align:right;">
                         <asp:RequiredFieldValidator runat=server ControlToValidate=dplPartyEntity_Type ErrorMessage="Entity type must be selected" ID="Entity_Type_ReqExpV" Display="Dynamic"> *
                         </asp:RequiredFieldValidator>

                         <asp:DropDownList ID="dplPartyEntity_Type" runat="server" Width="250px">
                             <asp:ListItem>South African - Private Company</asp:ListItem>
                             <asp:ListItem>South African - Public Company</asp:ListItem>
                             <asp:ListItem>South African - Close Corporation</asp:ListItem>
                             <asp:ListItem>South African - Trust</asp:ListItem>
                             <asp:ListItem>South African - Partnership</asp:ListItem>
                             <asp:ListItem>South African - Individual</asp:ListItem>
                             <asp:ListItem>Non South African - Individual</asp:ListItem>
                             <asp:ListItem>Non South African - Company, Trust or Partnership</asp:ListItem>
                             <asp:ListItem>Other</asp:ListItem>
                         </asp:DropDownList>
                         </div>
                     </p>
                     <p>
                            
                         <asp:Label ID="lblFullname" runat="server" Text="What is the Party's fullname?"></asp:Label>
                         <asp:RequiredFieldValidator runat=server ControlToValidate=txtParty_Fullname ErrorMessage="Please enter the party's fullname" ID="Party_Fullname_ReqExpV" Display="Dynamic"> *
                         </asp:RequiredFieldValidator>
                         <asp:TextBox ID="txtParty_Fullname" runat="server"></asp:TextBox>
                     </p>    
                     <p>
                         Will the Party be acting through a division? <asp:CheckBox ID="cbxParty_Division_Option" runat="server" />            
                     </p>
                     <p>
                         <asp:Label ID="Label11" runat="server" Text="What is the name of the Party's division?"></asp:Label>
                         <asp:TextBox ID="txtParty_Division_Name" runat="server"></asp:TextBox>
                     </p>
                     <p>
                         <asp:Label ID="Label12" runat="server" Text="Does the Party use a trading name?"></asp:Label>
                         <asp:CheckBox ID="cbxParty_Trading_Option" runat="server" />
                     </p>
                     <p>
                         <asp:Label ID="Label13" runat="server" Text="What is the Party's trading name?"></asp:Label>
                         <asp:TextBox ID="txtParty_Trading_Name" runat="server"></asp:TextBox>
                     </p>
                     <p>
                         <asp:Label ID="Label14" runat="server" Text="Enter the Party's registration number?"></asp:Label>
                         <%-- Add regular expression validator --%>
                         <asp:RequiredFieldValidator runat=server ControlToValidate=txtParty_Registration_Number ErrorMessage="Please enter the party's registration number" ID="Party_Registration_Number_ReqExpV" Display="Dynamic"> *
                         </asp:RequiredFieldValidator>
                         <asp:TextBox ID="txtParty_Registration_Number" runat="server"></asp:TextBox>
                     </p>
    
                     <p><b>Party's Contact details</b></p>
                     <p>
                         What is the Party's representative's title?
                         <div style="text-align:right;">
                         <asp:RequiredFieldValidator runat=server ControlToValidate=dplParty_Contact_Title ErrorMessage="Please select a title for the representative contact" ID="Party_Title_ReqExpV" Display="Dynamic"> *
                         </asp:RequiredFieldValidator>
                         <asp:DropDownList ID="dplParty_Contact_Title" runat="server">
                             <asp:ListItem>Mr</asp:ListItem>
                             <asp:ListItem>Mrs</asp:ListItem>
                             <asp:ListItem>Ms</asp:ListItem>
                             <asp:ListItem>Dr</asp:ListItem>
                             <asp:ListItem>Prof</asp:ListItem>
                         </asp:DropDownList>
                         </div>
                     </p>
                     <p>
                         <asp:Label ID="Label16" runat="server" Text="What is the Party's representative's fullname?"></asp:Label>
                         <asp:RequiredFieldValidator runat=server ControlToValidate=txtParty_Contact_Fullname ErrorMessage="Enter the fullname of the party representative" ID="Party_Contact_Fullname_ReqExpV" Display="Dynamic"> *
                         </asp:RequiredFieldValidator>
                         <asp:TextBox ID="txtParty_Contact_Fullname" runat="server"></asp:TextBox>
                     </p>
                     <p>
                         <asp:Label ID="Label6" runat="server" Text="What is the Party's representative's email address?"></asp:Label>
                         <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtParty_Email" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                         <asp:TextBox ID="txtParty_Email" runat="server"></asp:TextBox>
                     </p>
                     <p>
                         <asp:Label ID="Label17" runat="server" Text=""></asp:Label>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter valid Phone number" ControlToValidate="txtParty_Telephone" ValidationExpression="^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$" ></asp:RegularExpressionValidator>
                         What is the Party's representative's telephone number? <asp:TextBox ID="txtParty_Telephone" runat="server"></asp:TextBox>
                     </p>
                     <p>
                         <asp:Label ID="Label18" runat="server" Text="What is the Party's representative's fax number?"></asp:Label>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter valid Phone number" ControlToValidate="txtParty_Fax" ValidationExpression="^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$" ></asp:RegularExpressionValidator>
                         <asp:TextBox ID="txtParty_Fax" runat="server"></asp:TextBox>
                     </p>
                     <p>
                         <asp:Label ID="Label19" runat="server" Text="What is the Party's representative's physical address?"></asp:Label>
                         <asp:TextBox ID="txtParty_Physical_Address" runat="server"></asp:TextBox>
                     </p>
                     <p>
                         <asp:Label ID="Label20" runat="server" Text="Is the Party's representative's Postal address the same Physical address?"></asp:Label>
                         <asp:CheckBox ID="cbxParty_Physical_Same_Postal" runat="server" />        
                     </p>   
                     <p hidden="hidden">
                         <asp:Label ID="Label4" runat="server" Text="What is the Party's representative's postal address?"></asp:Label>
                         <asp:TextBox ID="txtParty_Postal_Address" runat="server"></asp:TextBox>
                     </p>
                </div>
                <div role="tabpanel" class="tab-pane" id="software">
                    <p>
                        <asp:Label ID="Label21" runat="server" Text="Name of Software component :"></asp:Label>
                        <asp:RequiredFieldValidator runat=server ControlToValidate=txtSoftware_Name ErrorMessage="Enter the name of the software" ID="Software_Name_ReqExpV" Display="Dynamic"> *
                        </asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtSoftware_Name" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        <asp:Label ID="Label22" runat="server" Text="What is the version number of the software component? "></asp:Label>
                        <asp:RequiredFieldValidator runat=server ControlToValidate=txtSoftware_Version ErrorMessage="Enter the version number of the software or N/A if not applicable" ID="Software_Version_ReqExpV" Display="Dynamic"> *
                        </asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtSoftware_Version" runat="server"></asp:TextBox>
                    </p>
                    <p hidden="hidden">
                        <asp:Label ID="Label23" runat="server" Text="Enter the description of the Software component"></asp:Label>
                        <asp:TextBox ID="txtSoftware_Description" runat="server"></asp:TextBox>
                    </p>
                    <p hidden="hidden">
                        <asp:Label ID="Label24" runat="server" Text="Software owner payment percentage :"></asp:Label>
                        <asp:TextBox ID="txtSoftware_Payment_Owner_Percentage" runat="server"></asp:TextBox>
                    </p>
                    <p hidden="hidden">
                        <asp:Label ID="Label25" runat="server" Text="Software beneficiary payment percentage :"></asp:Label>
                        <asp:TextBox ID="txtSoftware_Payment_Beneficiary_Percentage" runat="server"></asp:TextBox>
                    </p>
                </div>
            </div>
        </div>
    </div>
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    <asp:Button ID="btnAssemble" runat="server" Text="Assemble" OnClick="btnAssemble_Click1" />
        </form>
    
</body>
</html>


     
</asp:Content>
