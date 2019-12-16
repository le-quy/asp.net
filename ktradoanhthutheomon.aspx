<%@ Page Title="" Language="C#" MasterPageFile="~/GDadmin.Master" AutoEventWireup="true" CodeBehind="ktradoanhthutheomon.aspx.cs" Inherits="quan_ly_cafe.ktradoanhthutheomon" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" defaultfocus="btnhomnay">
        <center>
         <div style=" margin-left:100px;margin-right:100px;margin-top:100px">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="KIỂM TRA DOANH THU THEO MÓN" Font-Bold="True" ForeColor="Black" Font-Size="X-Large"></asp:Label>
                    </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td> 
                    <asp:Label ID="Label6" runat="server" Text="Doanh mục" ForeColor="Black"></asp:Label>
                    <asp:DropDownList ID="ddldoanhmuc" runat="server" AutoPostBack="True">
                        <asp:ListItem Selected="True" Value="Tất cả">Tất cả</asp:ListItem>
                        <asp:ListItem Value="CA PHE">Cà phê</asp:ListItem>
                        <asp:ListItem Value="NUOC EP">Nước ép</asp:ListItem>
                        <asp:ListItem Value="SUA CHUA">Sữa chua</asp:ListItem>
                        <asp:ListItem Value="TRA SUA">Trà sữa</asp:ListItem>
                    </asp:DropDownList>  
                    <br />
                        <asp:Button ID="btnhomnay" runat="server" Width="90" Height="45" Text="Hôm nay" OnClick="btnhomnay_Click" BackColor="DarkOrange" Font-Bold="True"></asp:Button>
                        <asp:Button ID="btntuchon" runat="server" Width="90" Height="45" Text="Tự chọn" style="margin-left:50px" OnClick="btntuchon_Click" BackColor="DarkOrange" Font-Bold="True"></asp:Button> 
                    <br />
                    <asp:Label ID="lbtb" runat="server" Text="" ForeColor="Red" ></asp:Label>           
                    <asp:Panel ID="pnngay" runat="server">
                        <asp:Label ID="Label3" runat="server" Text="Ngày" ForeColor="Black" Font-Bold="False"></asp:Label>
                        <asp:DropDownList ID="ddlngay" runat="server" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:Label ID="Label4" runat="server" Text="Tháng" ForeColor="Black"></asp:Label>
                        <asp:DropDownList ID="ddlthang" runat="server" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:Label ID="Label5" runat="server" Text="Năm" ForeColor="Black"></asp:Label>
                        <asp:DropDownList ID="ddlnam" runat="server" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:Button ID="btnchon" runat="server" OnClick="btnchon_Click" Text="Chọn" Width="54px" BackColor="#FF9900" Font-Bold="True" ForeColor="Black" />
                    </asp:Panel>

                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="pnds" runat="server">
                        <asp:GridView ID="gvdsmon" runat="server" style="margin-top:10px" AutoGenerateColumns="False" ForeColor="Black" >
                        <Columns>
                            <asp:BoundField DataField="TENMON" HeaderText="TÊN MÓN" />
                            <asp:BoundField DataField="SOLUONG" HeaderText="SỐ LƯỢNG" />
                            <asp:BoundField DataField="THANHTIEN" HeaderText="THÀNH TIỀN" />
                        </Columns>
                        <HeaderStyle BackColor="#FF9900" />
                    </asp:GridView>
                    <asp:Label ID="Label2" runat="server" Text="Tổng : " Font-Bold="True" ForeColor="Black"></asp:Label>
                    <asp:Label ID="lbtong" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
&nbsp;<br />
                    </asp:Panel>
                    
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
       </div>
        </center>
    </form>
</asp:Content>
