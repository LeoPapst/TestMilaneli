<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalculoCustos.aspx.cs" Inherits="MilaneliTest.CalculoCustos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Milaneli</title>
    <style>
        table { margin: auto; }
        p { margin: auto; }
        table.result { border-spacing: 5px; }
        td.result { background: #bcc3d1; padding:10px }
        th { background: #3c7bfa; padding:10px }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Label">Selecione o DDD de origem: </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="dropOrigem" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                         <asp:Label ID="Label2" runat="server" Text="Label">Selecione o DDD de destino: </asp:Label>
                     </td>
                     <td>
                        <asp:DropDownList ID="dropDestino" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Label">Selecione o plano desejado: </asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="dropPlanos" runat="server" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Label">Digite os minutos de ligação: </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMinLigacao" runat="server"></asp:TextBox><br />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btoCalculo" runat="server" Text="Calcular" 
                            onclick="btoCalculo_Click" />
                    </td>
                </tr>
            
            </table>
        </div>
        <div>
            <table id="resultados" border="1" class="result">
                <thead>
                    <tr>
                        <th>Origem</th>
                        <th>Destino</th>
                        <th>Tempo</th>
                        <th>Plano FaleMais</th>
                        <th><b>Com FaleMais</b></th>
                        <th><b>Sem FaleMais</b></th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td class="result"><asp:Label ID="labelOrigem" runat="server" Text="-"></asp:Label></td>
                        <td class="result"><asp:Label ID="labelDestino" runat="server" Text="-"></asp:Label></td>
                        <td class="result"><asp:Label ID="labelTempo" runat="server" Text="-"></asp:Label></td>
                        <td class="result"><asp:Label ID="labelPlano" runat="server" Text="-"></asp:Label></td>
                        <td class="result"><asp:Label ID="resultaComPlano" runat="server" Text="-"></asp:Label></td>
                        <td class="result"><asp:Label ID="resultaSemPlano" runat="server" Text="-"></asp:Label></td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div>
            <center><asp:Label ID="msgErro" runat="server" Text=""></asp:Label></center>
        </div>
    </form>
</body>
</html>
