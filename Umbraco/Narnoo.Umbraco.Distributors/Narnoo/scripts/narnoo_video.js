(function() {
	if ( typeof narnoo_video === 'undefined' ) {
		return;
	}
	
	jQuery(document).ready(function ($) {
		$(".narnoo_video").each(function() {
			var $that = $(this);
			$.ajax({
				url: narnoo_video_ajax_url,
				dataType: 'json',
				timeout: 60000,
				data: [
					{ 'name': 'narnoo_video_shortcode_count', 'value': $that.attr( 'data-count' ) },
					{ 'name': 'action', 'value': 'narnoo_operator_lib_request' },
					/*{ 'name': 'lib_path', 'value': narnoo_video_file_url },*/
					{ 'name': 'video_id', 'value': $that.attr( 'data-id' ) },
					{ 'name': 'width', 'value': $that.attr( 'data-width' ) },
					{ 'name': 'height', 'value': $that.attr('data-height') },
                    {
                        'name': 'operator_id',
                        'value': $that.attr('data-operator-id')
                    }
				],
				type: 'POST',
				error: function (jqXHR, textStatus, errorThrown) {
				    $that.html('Error (Narnoo Video): ' + textStatus + ' ' + errorThrown);
					console.error( 'Error (Narnoo Video): ' + textStatus + ' ' + errorThrown );
					console.error( jqXHR );
				},
				success: function( data, textStatus, jqXHR ) {
					$that.html( data.response );
					var i = $that.attr( 'data-count' );
					var flashvars = narnoo_video.flashvars[i];
					var params = {};
					params.play = "true";
					params.loop = "true";
					params.menu = "false";
					params.quality = "high";
					params.scale = "showall";
					params.wmode = "opaque";
					params.bgcolor = "#333333";
					params.devicefont = "false";
					params.allowfullscreen = "true";
					params.allowscriptaccess = "sameDomain";
					var attributes = {};
					attributes.id = "movee_player" + i;
					attributes.name = "movee_player" + i;
					attributes.align = "middle";
					swfobject.embedSWF(narnoo_video_url + 'player.swf', "narnooVideoFallback" + i, narnoo_video.widths[i], narnoo_video.heights[i], "9.0.0", narnoo_video_url + 'expressInstall.swf', flashvars, params, attributes);
				}
			});	
		});
	});
})();
