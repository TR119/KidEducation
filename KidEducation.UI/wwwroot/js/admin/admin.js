

    $(document).ready(function () {
        $('.nav-item a').click(function (e) {
            e.preventDefault();
            $('.nav-item').removeClass('active');
            $(this).closest('.nav-item').addClass('active');
            window.location = $(this).attr('href');
        });

        $('.nav-item a').each(function () {
            if (window.location.pathname === $(this).attr('href')) {
                $(this).closest('.nav-item').addClass('active');
            }
        });
    });
