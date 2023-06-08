# wazuh_DLP
----------------------------------------
DLP – Data Loss Prevention là một loại công nghệ sử dụng các công cụ phần mềm hỗ trợ và kỹ thuật nâng cao để bảo vệ dữ liệu quan trọng khỏi các truy cập trái phép. 

Wazuh - Công cụ cho phép giám sát, kiểm soát truy nhập máy chủ, phân tích các hành động của agent
Wazuh chia làm 2 bản
 - Wazuh server (Linux, Ubuntu, OVA - bản cài sẵn): có nhiệm vụ theo dõi, phân tích các bản ghi từ phía agent gửi lên và hiển thị dưới dạng danh sách và biểu đồ.
 - Wazuh Agent:  có nhiệm vụ theo dõi, gửi bản ghi lên phía server
Wazuh chỉ có hỗ trợ theo dõi, phân tích, gửi cảnh qua email thông qua bên thứ ba để theo dõi agent, Wazuh không thể tác động trực tiếp qua Agent.
Wazuh có hỗ trợ API nhưng cho đến hiện tại API đang ngừng hỗ trợ online chỉ gọi được theo local.
Wazuh server và Wazuh agent có cho phép thêm luật từ bên ngoài vào hệ thống.
----------------------------------------
Để tác động để máy agent, ta có thể sử dụng C# để tạo 1 chương trình chạy ngầm kiểm soát hành động của agent.Ở đây chúng tôi làm ví dụ về hành vi tác động đến file trong 1 folder gồm các hành động xóa, sửa, thêm, di chuyển file. Nếu hành động được thực hiện sẽ hiện cảnh báo, gửi thông báo đến email của admin và cưỡng chế đăng xuất tài khoản người dùng ra khỏi máy tính.
----------------------------------------
Dự định tương lai:
 -  Phát triển thêm các hành động theo dõi các hành vi người dùng 
 -  Thêm các chính sách kiểm soát các hành vi người dùng chặt chẽ hơn
 -  Kiểm soát các dữ liệu của các file dữ liệu (Mã hóa, xóa file khi có sự kiện tác động, thay đổi mật khẩu người dùng khi người dùng đăng nhập vi phạm chính sách)
