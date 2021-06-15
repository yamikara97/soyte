// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    var toggler = document.getElementsByClassName("caret");
    var i;

    for (i = 0; i < toggler.length; i++) {
        toggler[i].addEventListener("click", function () {
            this.parentElement.querySelector(".nested").classList.toggle("active");
            this.classList.toggle("caret-down");
        });
    }

    $('.table-data').DataTable().destroy();

    var t = $('.table-data').DataTable({
        "dom": '<"top"flp>',
        fixedHeader: {
            header: true
        },
        "language": {
            "lengthMenu": "Hiển  thị _MENU_ dòng trên một trang",
            "zeroRecords": "Không có bản ghi nào",
            "info": "Trang _PAGE_ trên _PAGES_",
            "infoEmpty": "Không có bản ghi nào",
            "infoFiltered": "(Kết quả trả về được duyệt trên tổng _MAX_ bản ghi)",
            "search": "Tìm kiếm:",
            "paginate": {
                "first": "Về đầu",
                "last": "Đến cuối",
                "next": "Tiếp",
                "previous": "Trước"
            },
        },
        "order": [[1, 'asc']],
        "pageLength": 20,
    });
    t.on('order.dt search.dt', function () {
        t.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();
    $(".dataTables_filter input").unbind();
    $(".dataTables_filter input").bind('keyup', function (e) {
        if (e.keyCode == 13) {
            $('.table-data').DataTable().search(this.value).draw();
        }
    });

});