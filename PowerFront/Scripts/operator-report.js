$(function () {

    $('#Pre-Defined').hide();
    $('#Custom').hide();
    ShowLoading();

    $.ajax({
        url: '/home/GetReportData',
        success: function (data) {
            var content = '';
            $.each(data, function (i, model) {
                content = content + '<tr>'
                content = content + '<td>' + model.ID + '</td>'
                content = content + '<td>' + model.Name + '</td>'
                content = content + '<td>' + model.ProactiveSent + '</td>'
                content = content + '<td>' + model.ProactiveAnswered + '</td>'
                content = content + '<td>' + model.ProactiveResponseRate + '</td>'
                content = content + '<td>' + model.ReactiveReceived + '</td>'
                content = content + '<td>' + model.ReactiveAnswered + '</td>'
                content = content + '<td>' + model.ReactiveResponseRate + '</td>'
                content = content + '<td>' + model.TotalChatLength + '</td>'
                content = content + '<td>' + model.AverageChatLength + '</td>'
                content = content + '</tr>'
            })
            $('#bodyContent').html(content);
        },
        error: function (error) {
            var content = '<tr><td colspan="10" style="text-align:center">No Data Found</td></tr>'
            $('#bodyContent').html(content);
            console.log(error.responseText);
        }
    });

    $('#radioBtn a').on('click', function () {
        var sel = $(this).data('title');
        switch (sel) {
            case "Pre-Defined":
                {
                    $('#Pre-Defined').show();
                    $('#Custom').hide();
                    break;
                }
            default:
                {
                    $('#Custom').show();
                    $('#Pre-Defined').hide();
                    break;
                }
        }
        var tog = $(this).data('toggle');
        $('#' + tog).prop('value', sel);

        $('a[data-toggle="' + tog + '"]').not('[data-title="' + sel + '"]').removeClass('active').addClass('notActive');
        $('a[data-toggle="' + tog + '"][data-title="' + sel + '"]').removeClass('notActive').addClass('active');
    });

    $('#btnApply').on('click', function () {
        ShowLoading();
        var data = $("#formFilter").serialize();
        $.ajax({
            url: '/home/GetFilteredReportData',
            data: data,
            success: function (data) {
                var content = '';
                $.each(data, function (i, model) {
                    content = content + '<tr>'
                    content = content + '<td>' + model.ID + '</td>'
                    content = content + '<td>' + model.Name + '</td>'
                    content = content + '<td>' + model.ProactiveSent + '</td>'
                    content = content + '<td>' + model.ProactiveAnswered + '</td>'
                    content = content + '<td>' + model.ProactiveResponseRate + '</td>'
                    content = content + '<td>' + model.ReactiveReceived + '</td>'
                    content = content + '<td>' + model.ReactiveAnswered + '</td>'
                    content = content + '<td>' + model.ReactiveResponseRate + '</td>'
                    content = content + '<td>' + model.TotalChatLength + '</td>'
                    content = content + '<td>' + model.AverageChatLength + '</td>'
                    content = content + '</tr>'
                })
                $('#bodyContent').html(content);
            },
            error: function (error) {
                var content = '<tr><td colspan="10" style="text-align:center">No Data Found</td></tr>'
                $('#bodyContent').html(content);
                console.log(error.responseText);
            }
        });
    });

    function ShowLoading() {
        var loading = '<tr><td colspan="10" style="text-align:center"><i class="fa fa-spinner fa-spin"></i></td></tr>'
        $('#bodyContent').html(loading);
    }

    $('#btnDownloadExel').on('click', function () {
        ShowLoading();
        var data = $("#formFilter").serialize();
        $.ajax({
            url: '/home/DownloadExcel',
            data: data,
            success: function (data) {
                var content = '';
                $.each(data, function (i, model) {
                    content = content + '<tr>'
                    content = content + '<td>' + model.ID + '</td>'
                    content = content + '<td>' + model.Name + '</td>'
                    content = content + '<td>' + model.ProactiveSent + '</td>'
                    content = content + '<td>' + model.ProactiveAnswered + '</td>'
                    content = content + '<td>' + model.ProactiveResponseRate + '</td>'
                    content = content + '<td>' + model.ReactiveReceived + '</td>'
                    content = content + '<td>' + model.ReactiveAnswered + '</td>'
                    content = content + '<td>' + model.ReactiveResponseRate + '</td>'
                    content = content + '<td>' + model.TotalChatLength + '</td>'
                    content = content + '<td>' + model.AverageChatLength + '</td>'
                    content = content + '</tr>'
                })
                $('#bodyContent').html(content);
            },
            error: function (error) {
                var content = '<tr><td colspan="10" style="text-align:center">No Data Found</td></tr>'
                $('#bodyContent').html(content);
                console.log(error.responseText);
            }
        });
    });
});