<%@ Page Title="" Language="C#" MasterPageFile="~/GDnhanvien.Master" AutoEventWireup="true" CodeBehind="phieutamtinhtn.aspx.cs" Inherits="quan_ly_cafe.phieutamtinhtn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">

    <table style="width:100%;">
          <tr>
                <td style="text-align:left; width: 800px;">
                </td>
                <td >
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/img/icon-ad.png"></asp:Image>
                    <asp:Label ID="lbnv" runat="server" Text="Tên nhân viên" ForeColor="Blue"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align:center; height: 50px;">
                    <asp:Label ID="Label5" runat="server" Text=" BÀN " ForeColor="#0066FF" Font-Bold="True" Font-Size="XX-Large" ></asp:Label>
                    &nbsp;<asp:Label ID="lbtenban" runat="server" ForeColor="#0066FF" Font-Bold="True" Font-Size="XX-Large" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center; width: 700px"> 
                    <asp:Button ID="btndsban" runat="server"  Height="40" Width="120" Text="SƠ ĐỒ BÀN" BackColor="#0066FF" Font-Bold="True" ForeColor="White" OnClick="btndsban_Click"></asp:Button>
                    <asp:Button ID="btndm" runat="server" style="margin-left:18px" Height="40" Width="150" Text="ĐẶT MÓN" BackColor="#0066FF" Font-Bold="True" ForeColor="White" OnClick="btndm_Click" />
                    <asp:Label ID="Label1" runat="server" style="margin-left:18px" Text="PHIẾU TẠM TÍNH " ForeColor="#000099" Font-Bold="True" Font-Size="X-Large" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></asp:Label>
                </td>
            </tr>
        <tr>
            <td style=" width: 800px; height: 114px;"> 
                <asp:Label ID="Label6" runat="server" Text="Chọn món: " style="margin-left:350px" ForeColor="Black"></asp:Label>
                <asp:Label ID="lbmonselected" style="margin-left:20px" runat="server"></asp:Label>
                <br />
                <asp:Label ID="Label7" runat="server" Text="Số lượng:" style="margin-left:350px" ForeColor="Black" ></asp:Label>
                <asp:TextBox ID="txtsl" runat="server" Width="50" style="margin-left:20px" TextMode="Number"></asp:TextBox>
                <br />
                <asp:Label ID="Label8" runat="server" Text="Ghi chú:" style="margin-left:350px" ForeColor="Black"></asp:Label>
                <asp:TextBox ID="txtghichu" Width="150" style="margin-left:20px"  runat="server"></asp:TextBox>
                <br />
               
            </td>
            <td style="height: 114px">

                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 800px">
                 <asp:Label ID="lbtb" style="margin-left:450px" runat="server" Text="HÓA ĐƠN" Font-Bold="True" ForeColor="Black"></asp:Label>
                <asp:GridView ID="gvtamtinh" style="margin-left:350px" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvtamtinh_SelectedIndexChanged" ForeColor="Black">
                    <Columns>
                        <asp:BoundField DataField="MAMON" HeaderText="M.Món" />
                        <asp:BoundField DataField="TENMON" HeaderText="T.Món" />
                        <asp:BoundField DataField="SOLUONG" HeaderText="S.Lượng" />
                        <asp:BoundField DataField="THANHTIEN" HeaderText="T.Tiền" />
                        <asp:CommandField ButtonType="Button" SelectText="Chọn" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Tổng tiền: " style="margin-left:450px" ForeColor="Black" Font-Bold="True"></asp:Label>
                <asp:Label ID="lbtien" runat="server" ForeColor="Black"></asp:Label>
                <br />
                <asp:Button ID="btnthemmon" runat="server" Text="Thêm món" style="margin-left:350px"  Width="100px" OnClick="btnthemmon_Click" Font-Bold="True" Font-Italic="True" ForeColor="#000099" />
                <asp:Button ID="btnhuymon" runat="server"  Text="Hủy món" style="margin-left:25px" Width="100px" OnClick="btnhuymon_Click" Font-Bold="True" Font-Italic="True" ForeColor="Red" />
                <asp:Button ID="btnchebien" runat="server" Text="Chế biến" style="margin-left:25px" Width="100px" OnClick="btnchebien_Click" Font-Bold="True" Font-Italic="True" ForeColor="#003300" />
                <br />
                <asp:Button ID="btninhoadon" runat="server" style="margin-left:350px; margin-top:10px" Width="100px" Text="In hóa đơn" Font-Bold="True" Font-Italic="True" OnClick="btninhoadon_Click" />
                <asp:Button ID="btnthanhtoan" runat="server" style="margin-left:25px"  Text="Thanh toán" Width="100px"  OnClick="btnthanhtoan_Click" Font-Bold="True" Font-Italic="True" ForeColor="#660066" />
                 <br />
                <asp:Image ID="Image2" style="margin-left:250px" runat="server" ImageUrl="~/img/icons8-coffee-to-go-100.png" />
                <asp:Image ID="Image3" style="margin-left:25px" runat="server" ImageUrl="~/img/icons8-mulled-wine-100.png" />
                <asp:Image ID="Image4" style="margin-left:25px" runat="server" ImageUrl="~/img/icons8-tea-cup-100.png" />
                <asp:Image ID="Image5" style="margin-left:25px" runat="server" ImageUrl="~/img/icons8-cafe-100.png" />
                 
            </td>
            <td>
                <br />
                <br />
                <br />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>

</form>
</asp:Content>
