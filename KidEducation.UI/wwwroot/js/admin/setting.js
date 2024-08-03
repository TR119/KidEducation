$(document).ready(function () {

    $('.btn-changePassword').on('click', function () {
        var oldPassword = $('#oldPassword').val();
        var newPassword = $('#newPassword').val();
        var confirmPassword = $('#confirmPassword').val();

        if (newPassword !== confirmPassword) {
            alert("Mật khẩu mới và nhập lại mật khẩu không khớp!");
            return;
        }

        $.ajax({
            url: '/admin/setting/changepassword', // Địa chỉ API của bạn
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({
                OldPassword: oldPassword,
                NewPassword: newPassword,
                ConfirmPassword: confirmPassword
            }),
            success: function (response) {
                if (response.Status === 200)
                    notificationService.success(response.Message);
                else
                    notificationService.error(response.Message);
            },
            error: function (error) {
                // Xử lý khi gọi API thất bại
                alert('Có lỗi xảy ra, vui lòng thử lại.');
            }
        });
    });

    $(".btn-updateEmailConfig").click(function () {

        var oldPassword = "1";
        var newPassword = "1";
        var confirmPassword = "1";
        // Collect form data
        var formData = {
            Id: $("input[name='Id']").val(),
            UserName: $("input[name='UserName']").val(),
            UseSSL: $("input[name='UseSSL']").val(),
            Host: $("input[name='Host']").val(),
            Port: $("input[name='Port']").val(),
            EmailId: $("input[name='EmailId']").val(),
            Password: $("input[name='Password']").val(),
            EmailToId: $("input[name='EmailToId']").val(),
            Name: $("input[name='Name']").val()
        };

        $.ajax({
            url: '/admin/setting/UpdateEmailConfig',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({
                Id: $("input[name='Id']").val(),
                UserName: $("input[name='UserName']").val(),
                UseSSL: false,
                Host: $("input[name='Host']").val(),
                Port: $("input[name='Port']").val(),
                EmailId: $("input[name='EmailId']").val(),
                Password: $("input[name='Password']").val(),
                EmailToId: $("input[name='EmailToId']").val(),
                Name: $("input[name='Name']").val()
            }),
            success: function (response) {
                if (response.Status === 200)
                    notificationService.success(response.Message);
                else
                    notificationService.error(response.Message);
            },
        error: function (xhr, status, error) {
            console.error("An error occurred:", error);
            // Handle error (e.g., display an error message)
        }
        });
    });


});
