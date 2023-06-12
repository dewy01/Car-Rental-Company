

var brandId = $('#brands').val();
var modelId = document.currentScript.getAttribute('modelId');
LoadModels();

$('#brands').change(function () {
    brandId = $(this).val();
    $('models').html('<option>Select Model</option>');
    LoadModels();
});

function LoadModels() {
    $.getJSON('/Cars/Create?handler=CarModels', { brandId: brandId }, function (data) {
        $.each(data, function (key, value) {
            var option = $('<option></option>').attr('value', value.id).text(value.name);
            if (value.id == modelId) {
                option.prop('selected', true);
            }
            $('#models').append(option);
        });
    });
}