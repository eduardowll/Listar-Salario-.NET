<%@ Page Title="Página Inicial" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" 
    Inherits="Projeto_ESIG.NET.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Listagem de Salários</h1>
        <p class="lead">Exibe os salários de funcionários e permite o recálculo.</p>
    </div>

    <div id="loading" style="display:none; margin-top:15px; font-weight:bold; color:red;">
        Processando... aguarde
    </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="row">
                <div class="col-md-12" style="margin-bottom: 20px;">
                    <asp:Button ID="btnRecalcular" runat="server" 
                                Text="Calcular/Recalcular Salários" 
                                OnClick="btnRecalcular_Click" 
                                CssClass="btn btn-primary btn-lg" />
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="gvPessoaSalario" runat="server" 
                                  AutoGenerateColumns="false" 
                                  CssClass="table table-hover table-striped"
                                  DataKeyNames="pessoa_id"
                                  OnRowEditing="gvPessoaSalario_RowEditing"
                                  OnRowUpdating="gvPessoaSalario_RowUpdating"
                                  OnRowCancelingEdit="gvPessoaSalario_RowCancelingEdit"
                                  OnRowDeleting="gvPessoaSalario_RowDeleting"
                                  EmptyDataText="Nenhum registro de salário encontrado. Clique em 'Calcular' para popular os dados.">
                        <Columns>
                            <asp:BoundField DataField="pessoa_id" HeaderText="ID" ReadOnly="true" />
                            <asp:BoundField DataField="pessoa_nome" HeaderText="Nome da Pessoa" ReadOnly="true" />


                            <asp:TemplateField HeaderText="Cargo">
                                <ItemTemplate>
                                    <%# Eval("cargo_nome") %>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlCargos" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="salario" HeaderText="Salário" DataFormatString="{0:C}" ReadOnly="true" />
                            <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnRecalcular" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(function () {
            document.getElementById("loading").style.display = "block";
        });
        prm.add_endRequest(function () {
            document.getElementById("loading").style.display = "none";
        });
    </script>

</asp:Content>
