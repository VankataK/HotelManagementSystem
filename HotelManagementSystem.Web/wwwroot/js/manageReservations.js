var $j = jQuery.noConflict();
$j(document).ready(function () {
    const roomId = $('#roomId').val();
    let unavailableDates = [];

    function loadUnavailableDates() {
        console.log("Loading unavailable dates for room ID:", roomId);
        return $j.ajax({
            url: '/Reservation/GetUnavailableDates',
            data: { roomId },
            method: 'GET',
            success: function (dates) {
                console.log("Unavailable dates received:", dates);
                unavailableDates = dates.map(date => new Date(date).toISOString().split('T')[0]);
            },
            error: function () {
                alert('Failed to load unavailable dates.');
            }
        });
    }

    function initializeDatepickers() {
        console.log("Initializing datepickers...");
        $j('#checkInDate').datepicker({
            dateFormat: 'yy-mm-dd',
            beforeShowDay: function (date) {
                const formattedDate = $j.datepicker.formatDate('yy-mm-dd', date);
                return [!unavailableDates.includes(formattedDate)];
            },
            onSelect: function (selectedDate) {
                console.log("Selected Check-In Date:", selectedDate);
                const checkInDate = new Date(selectedDate);
                $('#checkOutDate').datepicker('option', 'minDate', new Date(checkInDate.getTime() + 86400000));
            }
        });

        $j('#checkOutDate').datepicker({
            dateFormat: 'yy-mm-dd',
            beforeShowDay: function (date) {
                const formattedDate = $j.datepicker.formatDate('yy-mm-dd', date);
                return [!unavailableDates.includes(formattedDate)];
            }
        });
        console.log("Datepickers initialized.");
    }

    function calculatePrice() {
        const checkInDate = $j('#checkInDate').val();
        const checkOutDate = $j('#checkOutDate').val();

        if (roomId && checkInDate && checkOutDate) {
            $j.ajax({
                url: '/Reservation/CalculatePrice',
                data: { roomId, checkInDate, checkOutDate },
                success: function (response) {
                    $j('#totalPrice').val(response.totalPrice.toFixed(2));
                },
                error: function (xhr) {
                    alert(xhr.responseText || 'Failed to calculate the total price.');
                    $j('#totalPrice').val('');
                }
            });
        }
    }

    loadUnavailableDates().done(function () {
        initializeDatepickers();
    });

    calculatePrice();

    $j('#checkInDate, #checkOutDate').on('change', function () {
        calculatePrice();
    });
});