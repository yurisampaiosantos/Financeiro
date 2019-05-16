<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    <br />
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <br />
    <asp:Button ID="btImportArquivo" runat="server" Text="Gerar Arquivo" OnClick="btImportArquivo_Click" />
    <br />
    <asp:TextBox ID="txtSeq" runat="server" Visible="False"></asp:TextBox>
    <br />
    <asp:Panel ID="pnResultado" runat="server" Visible="False">
        <table>
            <tr>
                <td>Total Multa / Juros / Encargos</td>
                <td>
                    <asp:Label ID="lbEncargos" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Total Débitos:</td>
                <td>
                    <asp:Label ID="lbDebito" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Total Créditos:</td>
                <td>
                    <asp:Label ID="lbCredito" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Valor da Fatura Atual:</td>
                <td>
                    <asp:Label ID="lbTotal" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <asp:Panel ID="pnAlteracao" runat="server" Visible="False">
            <table style="width: 100%">
                <tr>
                    <td style="width: 192px; height: 20px"><strong>Fornecedor</strong></td>
                    <td style="height: 20px"></td>
                </tr>
                <tr>
                    <td style="width: 192px">
                        <asp:TextBox ID="txtCodigoFornecedor" runat="server" Width="177px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btAtualizar" runat="server" OnClick="btAtualizar_Click" Text="Atualizar" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server">
        <asp:GridView ID="gvResultado" runat="server" CellPadding="4" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" DataSourceID="objObjetoItauCard">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="DataDocumento" HeaderText="DataDocumento" SortExpression="DataDocumento" />
                <asp:BoundField DataField="Empresa" HeaderText="Empresa" SortExpression="Empresa" Visible="False" />
                <asp:BoundField DataField="DataLancamento" HeaderText="DataLancamento" SortExpression="DataLancamento" Visible="False" />
                <asp:BoundField DataField="Mes" HeaderText="Mes" SortExpression="Mes" Visible="False" />
                <asp:BoundField DataField="Moeda" HeaderText="Moeda" SortExpression="Moeda" Visible="False" />
                <asp:BoundField DataField="NotaFiscal" HeaderText="NotaFiscal" SortExpression="NotaFiscal" Visible="False" />
                <asp:BoundField DataField="TextoCabecalho" HeaderText="TextoCabecalho" SortExpression="TextoCabecalho" Visible="False" />
                <asp:TemplateField HeaderText="Fornecedor" SortExpression="Fornecedor">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Fornecedor") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbFornecedor" runat="server" Text='<%# Bind("Fornecedor") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ValorTotal" HeaderText="ValorTotal" SortExpression="ValorTotal" Visible="False" />
                <asp:BoundField DataField="Vencimento" HeaderText="Vencimento" SortExpression="Vencimento" />
                <asp:BoundField DataField="ContaDespesa" HeaderText="ContaDespesa" SortExpression="ContaDespesa" />
                <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
                <asp:BoundField DataField="Passageiro" HeaderText="Passageiro" SortExpression="Passageiro" />
                <asp:BoundField DataField="ValorItem" HeaderText="ValorItem" SortExpression="ValorItem" />
                <asp:TemplateField HeaderText="CentroCusto" SortExpression="CentroCusto">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("CentroCusto") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="txtCentroCusto" runat="server" Enabled='<%# Eval("Alterar") %>' Text='<%# Bind("CentroCusto") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ElementoPep" SortExpression="ElementoPep">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ElementoPep") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="txtElementoPep" runat="server" Enabled='<%# Eval("Alterar") %>' Text='<%# Bind("ElementoPep") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OrdemInterna" SortExpression="OrdemInterna">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("OrdemInterna") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="txtOrdemInterna" runat="server" Enabled='<%# Eval("Alterar") %>' Text='<%# Bind("OrdemInterna") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Não Encontrado" SortExpression="NaoEncontrado">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("NaoEncontrado") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="txtNaoEncontrado" runat="server" Text='<%# Bind("NaoEncontrado") %>' Visible='<%# Eval("Alterar") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <asp:ObjectDataSource ID="objObjetoItauCard" runat="server" SelectMethod="ListagemAgrupada" TypeName="NEG.LayoutSAPNEG">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtSeq" Name="seqId" PropertyName="Text" Type="Decimal" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:Button ID="btCSV" runat="server" OnClick="btCSV_Click" Text="Gerar CSV" Visible="False" />
        <br />
        <br />
    </asp:Panel>
    <center>
    <asp:GridView ID="gvDePara" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDePara" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
        <Columns>
            <asp:BoundField DataField="De" HeaderText="De" SortExpression="De" />
            <asp:BoundField DataField="Para" HeaderText="Para" SortExpression="Para" />
        </Columns>
        <FooterStyle BackColor="Tan" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <SortedAscendingCellStyle BackColor="#FAFAE7" />
        <SortedAscendingHeaderStyle BackColor="#DAC09E" />
        <SortedDescendingCellStyle BackColor="#E1DB9C" />
        <SortedDescendingHeaderStyle BackColor="#C2A47B" />
    </asp:GridView>
    </center>
    <asp:ObjectDataSource ID="ObjectDePara" runat="server" SelectMethod="ListDePara" TypeName="NEG.LayoutSAPNEG">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtSeq" Name="seqId" PropertyName="Text" Type="Decimal" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
</asp:Content>

