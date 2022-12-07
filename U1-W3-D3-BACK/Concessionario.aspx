<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Concessionario.aspx.cs" Inherits="U1_W3_D3_BACK.Concessionario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="StyleSheet1.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container">
                <div class="row">
                    <div>
                        <h2>Lista Auto</h2>
                        <asp:DropDownList ID="ddlAuto" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAuto_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text=""></asp:ListItem>
                        </asp:DropDownList>
                        <asp:Image ID="CarImage" runat="server" />
                    </div>
                    <hr />

                </div>
                <div class="row">
                    <div>
                        <h2>Optional</h2>
                        <asp:CheckBoxList ID="CheckBoxOptional" runat="server">
                            <asp:ListItem Text="Sistema infotainment" Value="200"></asp:ListItem>
                            <asp:ListItem Text="Fari Full LED" Value="300"></asp:ListItem>
                            <asp:ListItem Text="Sedili riscaldati" Value="400"></asp:ListItem>
                        </asp:CheckBoxList>
                        <h2>Scegli la tua garanzia, 120 Euro all'anno</h2>
                        <asp:DropDownList ID="ddlGaranzia" runat="server">
                            <asp:ListItem Text="1 anno" Value="120"></asp:ListItem>
                            <asp:ListItem Text="2 anni" Value="240"></asp:ListItem>
                            <asp:ListItem Text="3 anni" Value="360"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <hr />
                </div>
                <div class="row">
                    <div>
                        <asp:Button ID="ConfermaAcquisto" runat="server" Text="Conferma" OnClick="ConfermaAcquisto_Click" />
                        Riepilogo: <asp:Label ID="TotaleAcquisto" runat="server" Text="" ></asp:Label>
                        Totale: <asp:Label ID="PrezzoTotale" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
