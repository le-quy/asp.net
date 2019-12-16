<%@ Page Title="" Language="C#" MasterPageFile="~/GDadmin.Master" AutoEventWireup="true" CodeBehind="ktradoanhthutheongay.aspx.cs" Inherits="quan_ly_cafe.ktradoanhthutheongay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form id ="form" runat ="server">
    <center> 
    <div style=" margin-left:100px;margin-right:100px;margin-top:100px">
    <table >
        <tr>
            <td style="height: 26px"></td>
            <td style="height: 26px">
                <asp:Label ID="Label1" runat="server" Text="KIỂM TRA DOANH THU THEO NGÀY" Font-Bold="True" Font-Size="X-Large" ForeColor="Black"></asp:Label>
            &nbsp;<br />
                <asp:Button ID="btnhomnay" runat="server" Width="90" Height="45" Text="Hôm nay" OnClick="btnhomnay_Click" BackColor="DarkOrange" Font-Bold="True" ForeColor="Black" />
                <asp:Button ID="btntuchon" runat="server" Width="90" Height="45" Text="Tự chọn" style="margin-left:50px"  OnClick="btntuchon_Click" BackColor="DarkOrange" Font-Bold="True" ForeColor="Black" />
                <br />
                <asp:Label ID="lbtb" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
            <td style="height: 26px"></td>
        </tr>
        <tr>
            <td style="height: 29px"></td>
            <td style="height: 29px">
                <asp:Panel ID="pnngay" runat="server">
                    <asp:Label ID="Label2" runat="server" Text="Từ ngày" ForeColor="Black"></asp:Label>
                    <asp:DropDownList ID="ddlngay1"  runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                    &nbsp;<asp:Label ID="Label5" runat="server" ForeColor="Black" Text="Tháng"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlthang1" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:Label ID="Label6" runat="server" ForeColor="Black" Text="Năm"></asp:Label>
                    <asp:DropDownList ID="ddlnam1" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Đến ngày" style="margin-top:10px" ForeColor="Black"></asp:Label>
                    <asp:DropDownList ID="ddlngay2"  runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:Label ID="Label7" runat="server" ForeColor="Black" Text="Tháng"></asp:Label>
                    <asp:DropDownList ID="ddlthang2" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:Label ID="Label8" runat="server" ForeColor="Black" Text="Năm"></asp:Label>
                    <asp:DropDownList ID="ddlnam2" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                    <br />
                    <asp:Button ID="btnchon" runat="server" style="margin-top:10px" Text="Chọn" OnClick="btnchon_Click" BackColor="#FF9900" Font-Bold="True" ForeColor="Black" />
                    <br />
                </asp:Panel>
            </td>
            <td style="height: 29px"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td><asp:Panel ID="pnds" runat="server">
                <asp:GridView ID="gvds" runat="server" AutoGenerateColumns="False" ForeColor="Black">
                    <Columns>
                        <asp:BoundField DataField="TENMON" HeaderText="TÊN MÓN" />
                        <asp:BoundField DataField="SOLUONG" HeaderText="SỐ LƯỢNG" />
                        <asp:BoundField DataField="THANHTIEN" HeaderText="THÀNH TIỀN" />
                    </Columns>
                    <HeaderStyle BackColor="#FF9900" />
                </asp:GridView>
                <br />
                <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="Black" Text="Tổng tiền : "></asp:Label>
                <asp:Label ID="lbtt" runat="server" ForeColor="Black"></asp:Label>
                </asp:Panel>
                
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    </div>
    </center>
   </form>

</asp:Content>
