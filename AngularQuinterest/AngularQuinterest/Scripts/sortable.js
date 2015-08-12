
$('.sortThis').sortable({
    update: function (e, ui) {
            var order = $(this).sortable('toArray');

            $.ajax({
                data: JSON.stringify(order),
                type: 'POST',
                url: '/api/pins/saveOrder',
                contentType: 'application/json',
                dataType: 'json'
            });
        }
    }).disableSelection();
