(function () {
    if (typeof narnoo_brochure === 'undefined') {
        return;
    }

    jQuery(document).ready(function ($) {
        $('.narnoo_brochure').each(function () {
            var $that = $(this);

            data = [
				{ 'name': 'narnoo_brochure_shortcode_count', 'value': $that.attr('data-count') },
				{ 'name': 'action', 'value': 'narnoo_distributor_lib_request' },
				{ 'name': 'lib_path', 'value': narnoo_brochure_file_url },
				{ 'name': 'brochure_width', 'value': $that.attr('data-width') },
				{ 'name': 'brochure_height', 'value': $that.attr('data-height') },
				{ 'name': 'brochure_id', 'value': $that.attr('data-id') },
				{ 'name': 'image', 'value': $that.attr('data-image') },
				{ 'name': 'align', 'value': $that.attr('data-align') },
				{ 'name': 'img_alt', 'value': $that.attr('data-img-alt') },
				{ 'name': 'img_title', 'value': $that.attr('data-img-title') },
				{ 'name': 'operator_id', 'value': $that.attr('data-operator-id') }
            ];

            if (typeof $that.attr('data-caption') !== 'undefined') {
                data.push({ 'name': 'caption', 'value': $that.attr('data-caption') });
            }

            $.ajax({
                url: narnoo_brochure_ajax_url,
                dataType: 'json',
                timeout: 60000,
                data: data,
                type: 'POST',
                error: function (jqXHR, textStatus, errorThrown) {
                    console.error('Error (Narnoo Brochure): ' + textStatus + ' ' + errorThrown);
                    console.error(jqXHR);
                },
                success: function (data, textStatus, jqXHR) {
                    $that.html(data.response);
                }
            });
        });
    });
})();
