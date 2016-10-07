Để kết nối cơ sở dữ liệu tiến hành chọn chuột phải vào project
-> chọn properties -> setting -> chọn type là loại connectionstring
-> thêm vào phần value đoạn connection sau:
-> Data Source=@ServerName;Initial Catalog=QuanLiKho;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=QuanLiKho
-> trong đó ServerName là tên của sql server