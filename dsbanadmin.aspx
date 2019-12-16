<%@ Page Title="" Language="C#" MasterPageFile="~/GDadmin.Master" AutoEventWireup="true" CodeBehind="dsbanadmin.aspx.cs" Inherits="quan_ly_cafe.dsbanadmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
    <form id="form1" runat="server">   
        <table >
            <tr>
                <td>                                  
                </td>
                <td style="height: 45px; width: 200px;">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/img/icon-ad.png"></asp:Image>
                    <asp:Label ID="lbtennv" runat="server" ForeColor="Blue"></asp:Label></td>
            </tr>
            <tr>
                <td style="text-align:left">
                     <asp:Image ID="Image2" ImageUrl="~/img/icons8-coffee-table-100.png" Height="80" Width="80" runat="server"></asp:Image>
                    <asp:Label ID="Label1"  runat="server" Text="SƠ ĐỒ BÀN" ForeColor="#0066FF" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align:center">
                    <asp:Image ID="Image3" ImageUrl="~/img/icons8-location-96.png"  Width="50px" Height="50px" runat="server"></asp:Image>
                    <asp:Label ID="Label2" runat="server" Text="Khu vực : " Font-Size="Medium" ForeColor="Blue" Font-Bold="True"></asp:Label>
                     <asp:Button ID="btnall" runat="server" style="margin-left: 18px" Text=" Tất cả " Width="90" Height="45" BackColor="#FF3300" Font-Bold="True" ForeColor="White" OnClick="btnall_Click" ></asp:Button>
                    <asp:Button ID="btnkva" runat="server" style="margin-left: 18px" Text="A" Width="90" Height="45" BackColor="#FF3300" Font-Bold="True" ForeColor="White" OnClick="btnkva_Click" ></asp:Button>
                    <asp:Button ID="btnkvb" runat="server" style="margin-left: 18px" Text=" B" Width="90" Height="45" BackColor="#FF3300" Font-Bold="True" ForeColor="White" OnClick="btnkvb_Click"></asp:Button>
                </td>     
                <td ></td>
                <td></td>
            </tr>
            <tr>
                <td style="text-align:center" >
                    <asp:Panel ID="pnkhua" Width="700" runat="server">
                        <asp:Button ID="btn1" style="margin-top: 18px" runat="server" Text="1" OnClick="btn1_Click" Width="100" Height="50" />
                        <asp:Button ID="btn2" style="margin-left: 18px" runat="server" Text="2" OnClick="btn2_Click" Width="100" Height="50" />
                        <asp:Button ID="btn3" style="margin-left: 18px" runat="server" Text="3" OnClick="btn3_Click" Width="100" Height="50" />
                        <asp:Button ID="btn4" style="margin-left: 18px"  runat="server" Text="4" OnClick="btn4_Click" Width="100" Height="50" />
                        <asp:Button ID="btn5" style="margin-left: 18px" runat="server" Text="5" OnClick="btn5_Click" Width="100" Height="50"/>
                        <br />
                        <asp:Button ID="btn6" style="margin-top: 18px" runat="server" Text="6" OnClick="btn6_Click" Width="100" Height="50"/>
                        <asp:Button ID="btn7" style="margin-left: 18px" runat="server" Text="7" OnClick="btn7_Click" Width="100" Height="50" />
                        <asp:Button ID="btn8" style="margin-left: 18px" runat="server" Text="8" OnClick="btn8_Click" Width="100" Height="50" />
                        <asp:Button ID="btn9" style="margin-left: 18px" runat="server" Text="9" OnClick="btn9_Click" Width="100" Height="50" />
                        <asp:Button ID="btn10" style="margin-left: 18px"  runat="server" Text="10" OnClick="btn10_Click" Width="100" Height="50"/>     
                    </asp:Panel>
                    <asp:Panel ID="pnkhub" Width="700" runat="server">         
                        <asp:Button ID="btn11" style="margin-top: 18px"  runat="server" Text="11" OnClick="btn11_Click" Width="100" Height="50"/>
                        <asp:Button ID="btn12" style="margin-left: 18px" runat="server" Text="12" OnClick="btn12_Click" Width="100" Height="50" />
                        <asp:Button ID="btn13" style="margin-left: 18px" runat="server" Text="13" OnClick="btn13_Click" Width="100" Height="50"/>
                        <asp:Button ID="btn14" style="margin-left: 18px" runat="server" Text="14" OnClick="btn14_Click" Width="100" Height="50"/>
                        <asp:Button ID="btn15" style="margin-left: 18px" runat="server" Text="15" OnClick="btn15_Click" Width="100" Height="50"/>
                    <br />
                        <asp:Button ID="btn16" style="margin-top: 18px"  runat="server" Text="16" OnClick="btn16_Click" Width="100" Height="50"/>
                        <asp:Button ID="btn17" style="margin-left: 18px" runat="server" Text="17" OnClick="btn17_Click" Width="100" Height="50"/>
                        <asp:Button ID="btn18" style="margin-left: 18px" runat="server" Text="18" OnClick="btn18_Click" Width="100" Height="50"/>
                       <asp:Button ID="btn19"  style="margin-left: 18px" runat="server" Text="19" OnClick="btn19_Click" Width="100" Height="50" > </asp:Button>
                        <asp:Button ID="btn20" style="margin-left: 18px" runat="server" Text="20" OnClick="btn20_Click" Width="100" Height="50" ></asp:Button>
                    </asp:Panel>
                     <asp:Panel ID="pnchucnang" style="margin-top: 18px" Width="700" runat="server" >
                        <asp:Label ID="lbtrong" runat="server" ForeColor="Black" Text="Trống - "></asp:Label>
                        <asp:Image ID="imggray" runat="server" Height=" 50" ImageUrl="~/img/gray.png" Width="50" />
                        <asp:Label ID="lbcokhach" style="margin-left: 10px"   runat="server" Text="Có Khách - " ForeColor="Black"></asp:Label>
                        <asp:Image ID="imgblue" runat="server" Height=" 50" ImageUrl="~/img/blue.png" Width="50" />
                         <asp:Label ID="lbyeucau" style="margin-left: 10px" runat="server" Text="Yêu cầu thanh toán - " ForeColor="Black"></asp:Label>
                        <asp:Image ID="imgyellow" ImageUrl="~/img/yellow.jpg" Width ="50" Height =" 50" runat="server" />
                        <br />
                                   
                    </asp:Panel>
                      <asp:Panel ID="pnchuyenban" Width="700" style="margin-top: 18px" runat="server">
                        <asp:Label ID="Label4" runat="server" Text="Từ bàn có khách: " ForeColor="Black"></asp:Label>
                        <asp:TextBox ID="txtbancu" runat="server" Height="30" Width ="30"></asp:TextBox>
                        <asp:Label ID="Label5"  style="margin-left: 20px" runat="server" Text="Sang bàn trống: " ForeColor="Black"></asp:Label>
                        <asp:TextBox ID="txtbanmoi" runat="server" Height="30" Width ="30"></asp:TextBox>
                        <asp:Button ID="btnthchuyenban" runat="server" Text="Chuyển" OnClick="btnthchuyenban_Click" style="margin-left: 20px" Height="40" Width="70" />
                    </asp:Panel>
                    <asp:Panel ID="pnghepban" Width="700" style="margin-top: 18px" runat="server">
                        <asp:Label ID="Label3" runat="server" Text="Từ bàn có khách: " ForeColor="Black"></asp:Label>
                        <asp:TextBox ID="txtbancughep" runat="server" Height="30" Width ="30"></asp:TextBox>
                        <asp:Label ID="Label8" runat="server" Text="Sang bàn có khách: " ForeColor="Black" style="margin-left: 20px" ></asp:Label>
                        <asp:TextBox ID="txtbanmoighep" runat="server" Height="30" Width ="30"></asp:TextBox>
                        <asp:Button ID="btnthghepban" runat="server" Text="Ghép" OnClick="btnthghepban_Click" style="margin-left: 20px" Height="40" Width="60"  />
                    </asp:Panel>
                     <asp:Panel ID="pntachban" style="margin-top: 18px" runat="server">
                            <asp:Label ID="Label9" runat="server" Text="Từ bàn có khách: " ForeColor="Black"></asp:Label>
                            <asp:TextBox ID="txtbantachcu" Height="30" Width ="30" runat="server"></asp:TextBox>
                            <asp:Label ID="Label10" runat="server" Text="Sang bàn: " ForeColor="Black" style="margin-left: 20px" ></asp:Label>
                            <asp:TextBox ID="txtbantachmoi" Height="30" Width ="30" runat="server" ></asp:TextBox>
                            <asp:Button ID="btnthchonban" runat="server" Text="Chọn" style="margin-left: 20px" Height="40" Width="60" OnClick="btnthchonban_Click" />                           
                        </asp:Panel>
                        <asp:Panel style= "text-align:center" ID="pnhoadon" Width="700" runat="server">
                            <asp:Label ID="Label6" runat="server" Text="Chọn món: " ForeColor="Black"></asp:Label>
                            <asp:Label ID="lbmonselected" runat="server" ForeColor="Black"></asp:Label>
                            <br />
                            <asp:Label ID="Label7" runat="server" Text="Số lượng:" ForeColor="Black"></asp:Label>
                            <asp:TextBox ID="txtsl" runat="server" Height="30" Width ="30" TextMode="Number" ></asp:TextBox>
                            <br />
                            <asp:Button ID="btnthtach" runat="server" Text="Tách" Height="40" Width="60" OnClick="btnthtach_Click" />
                            <br />
                            <asp:GridView ID="gvdanhsachmon" runat="server" style="margin-left:200px" AutoGenerateColumns="False" OnSelectedIndexChanged="gvdanhsachmon_SelectedIndexChanged" ForeColor="Black">
                                    <Columns>
                                        <asp:BoundField DataField="MAMON" HeaderText="MÃ MÓN" />
                                        <asp:BoundField DataField="TENMON" HeaderText="TÊN MÓN" />
                                        <asp:BoundField DataField="SOLUONG" HeaderText="SỐ LƯỢNG" />
                                        <asp:BoundField DataField="THANHTIEN" HeaderText="THÀNH TIỀN" />
                                        <asp:CommandField ButtonType="Button" SelectText="Chọn" ShowSelectButton="True" />
                                    </Columns>
                                    <HeaderStyle BackColor="#FF9900" />
                                </asp:GridView>                             
                    </asp:Panel>
                   
                </td>
               <td style="text-align:left; width: 200px;" >
                        <asp:Label ID="Label11" runat="server" Text="Chức năng : " ForeColor="Black" Font-Bold="True" Font-Size="Large" Font-Underline="True"></asp:Label>
                        <br />
                        <asp:Button ID="btnchuyenban" style="margin-top: 18px" runat="server" Text="Chuyển bàn" OnClick="btnchuyenban_Click" Width="100px" Height="40px" ForeColor="Blue" Font-Bold="True" Font-Italic="True"/>
                        <br />
                        <asp:Button ID="btntachban" style="margin-top: 18px" runat="server" Text="Tách bàn" OnClick="btntachban_Click" Width="100" Height="40" ForeColor="Red" Font-Bold="True" Font-Italic="True"/>
                        <br />    
                        <asp:Button ID="btnghepban" style="margin-top: 18px" runat="server" Text="Ghép bàn" OnClick="btnghepban_Click" Width="100" Height="40" ForeColor="#003300" Font-Bold="True" Font-Italic="True" />
                                   
                </td>
            </tr>
        </table>
    </form>
  </center>

</asp:Content>
