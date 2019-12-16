<%@ Page Title="" Language="C#" MasterPageFile="~/GDnhanvien.Master" AutoEventWireup="true" CodeBehind="datmonnv.aspx.cs" Inherits="quan_ly_cafe.datmon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
    <form id="form1" runat="server">
        
        <table style="width: 912px" >
            <tr>
                <td style="text-align:left; width: 624px;">
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
                    <asp:Label ID="Label1" runat="server" style="margin-left:18px" Text=" ĐẶT MÓN " ForeColor="#000099" Font-Bold="True" Font-Size="X-Large" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></asp:Label>
                    <asp:Button ID="btnptt" runat="server" style="margin-left:18px" Height="40" Width="150" Text="PHIẾU TẠM TÍNH" OnClick="btnptt_Click" BackColor="#0066FF" Font-Bold="True" ForeColor="White" />
                </td>
            </tr>
            <tr>
                <td style="text-align:center;width: 624px">

                    <asp:Button ID="btncf" style="margin-top:18px" runat="server" Text="CÀ PHÊ" Width="100px" Height="50px" Font-Bold="True" ForeColor="Maroon" BackColor="White" OnClick="btncf_Click"  />
                    <asp:Button ID="btnnuocep" runat="server" Text="NƯỚC ÉP" Width="100px" Height="50px" Font-Bold="True" ForeColor="#003300" BackColor="White" OnClick="btnnuocep_Click"  />
                    <asp:Button ID="btntrasua" runat="server" Text="TRÀ SỮA" Width="100px" Height="50px" Font-Bold="True" ForeColor="Red" BackColor="White" OnClick="btntrasua_Click"  />
                    <asp:Button ID="btnsuachua" runat="server" Text="SỮA CHUA" Width="100px" Height="50px" Font-Bold="True" ForeColor="#660066" BackColor="White" OnClick="btnsuachua_Click"  />
                    <br />
                     <asp:TextBox ID="txttenmon" runat="server" Height="30px" Width="300 "></asp:TextBox>
                <asp:Button ID="btntim" style="margin-top:18px" Height="40px" Width="100" runat="server" Text="Tìm kiếm" OnClick="btntim_Click" BackColor="#FF6600" Font-Bold="True" Font-Italic="True" ForeColor="White" ></asp:Button>
                    </td>
                    <td style="text-align:left">
                       <asp:Image ID="Image6" ImageUrl="~/img/icons8-cocktail-100.png" runat="server" />
                        <asp:Image ID="Image4" style="margin-left:18px"  ImageUrl="~/img/icons8-coconut-cocktail-100.png" runat="server" />
                
                </td>
            </tr>
            <tr>
                <td style="width: 624px">                
                    <asp:GridView style="margin-left:125px" ID="dsmon" runat="server" AutoGenerateColumns="False" Width="300px" AllowPaging="True" OnSelectedIndexChanged="dsmon_SelectedIndexChanged" Font-Bold="True" ForeColor="Black" OnPageIndexChanging="dsmon_PageIndexChanging" >
                        <AlternatingRowStyle Font-Bold="True" ForeColor="Black" />
                        <Columns>
                            <asp:BoundField DataField="MAMON" HeaderText="MÃ MÓN" >
                            <ControlStyle Width="40px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TENMON" HeaderText="TÊN MÓN" />
                            <asp:BoundField DataField="DONGIA" HeaderText="ĐƠN GIÁ" />
                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/icons8-hand-left-50.png" ShowSelectButton="True">
                            <ControlStyle Height="30px" Width="30px" />
                            </asp:CommandField>
                        </Columns>
                        <EditRowStyle Font-Bold="True" ForeColor="Black" />
                        <FooterStyle ForeColor="#003300" />
                        <HeaderStyle BackColor="#FFCC00" ForeColor="#000066" />
                        <RowStyle BackColor="White" />
                    </asp:GridView>                  
                </td>
                <td style="text-align:left ">                 
                    <asp:Label ID="Label8" runat="server" Text="Thông tin món" Font-Bold="True" ForeColor="Black"></asp:Label>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="-Chọn món:" ForeColor="Black"></asp:Label>
                    <asp:Label ID="lbtenmon" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="-Đơn giá: " ForeColor="Black"></asp:Label>
                    <asp:Label ID="lbgia" runat="server" Font-Bold="True" ForeColor="Black" Text=""></asp:Label>
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="-Số lượng: " ForeColor="Black" ></asp:Label>
                    <asp:TextBox ID="txtsl" runat="server" Height="30" Width="30"  TextMode="Number"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="-Ghi chú: " ForeColor="Black"></asp:Label>
                    <asp:TextBox ID="txtghichu" Height="30" Width="150" runat="server"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnxacnhan" style="margin-top:18px; margin-left:50px" runat="server" Height="33px" OnClick="btnxacnhan_Click" Text="Xác nhận" BackColor="#003300" Font-Bold="True" Font-Italic="True" ForeColor="White" />
                    <br />
                    <br />
                        <asp:Image ID="Image5" style="margin-left:18px" ImageUrl="~/img/icons8-milkshake-100.png" runat="server" />
                        <asp:Image ID="Image7" style="margin-left:18px" ImageUrl="~/img/icons8-bar-100.png" runat="server" />
                
                </td>
            </tr>
        </table>
        
    </form>
    </center>
</asp:Content>
