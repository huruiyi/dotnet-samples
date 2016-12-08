(function ($) {
	$.fn.imageUploaderCut = function (options) {
		var innerOptions = {
			fileInputId: options.fileInputId || 'image-uploader-cut-input',
			pluginObject: this,
			apertureWidth: options.apertureWidth || 300,
			apertureHeight: options.apertureHeight || 300,
			proceedCallBack: options.proceedCallBack
		};
		this.append('<input type="file" name="files" value="" multiple="multiple" accept="image/*" id="' + innerOptions.fileInputId + '"/>');
		this.append('<input type="button" name="getCroppedImagesJson" value="I am done"/>');
		this.append('<div id="cropContainer"></div>');
		$('#' + innerOptions.fileInputId).change(function (e) {
			$('#cropContainer').empty();
			read(this, innerOptions);
		});

		$('input[name=getCroppedImagesJson]').click(function () {
			var results = new Array();
			$('.cropAperture').each(function (index, value) {
				var aperture = $(value);
				var img = aperture.find('img');
			var o = {
				'Content': img.attr('src'),
				'FileName': aperture.attr('data-filename'),
				'ContentLenght': aperture.attr('data-filesize'),
				'ImgWidth': img.width(),
				'ImgHeight': img.height(),
				'CropX': Math.abs(parseInt(img.css('left'))),
				'CropY': Math.abs(parseInt(img.css('top'))),
				'CropWidth': aperture.width(),
				'CropHeight': aperture.height()
			};
				results.push(o);
			});
			if (innerOptions.proceedCallBack) {
				innerOptions.proceedCallBack(JSON.stringify(results));
			}
		});

		var read = function (input, opt) {
			$(input.files).each(function (index, value) {
				var reader = new FileReader();
				reader.onload = function (e) {
					var imgId = 'preview' + index;
					var apertureId = 'aperture' + index;
					$('#cropContainer').append('<div class="cropAperture" id="' + apertureId + '" data-filename="' + value.name + '" data-filesize="' + value.size + '"><img id="' + imgId + '" /> </div>');
					var img = $('#' + imgId);
					var aperture = $('#' + apertureId);
					aperture.css({
						'width': opt.apertureWidth + 'px',
						'height': opt.apertureHeight + 'px',
						'z-index': 10,
						'margin': '20px',
						'overflow': 'hidden'
					});
					img.css('z-index', 9);
					img.attr('src', e.target.result);
					img.attr('zoomfactor', 0);
					img.draggable({
						drag: function (event, ui) {
							if (ui.position.left > 0)
								ui.position.left = 0;
							if (ui.position.top > 0)
								ui.position.top = 0;
							var topoffset = ui.helper.height() - ui.helper.parent().height();
							if (Math.abs(ui.position.top) > topoffset)
								ui.position.top = topoffset * -1;
							var leftoffset = ui.helper.width() - ui.helper.parent().width();
							if (Math.abs(ui.position.left) > leftoffset)
								ui.position.left = leftoffset * -1;
						}
					});
					aperture.bind('mousewheel', function (event) {
						var increment = event.originalEvent.wheelDelta / 120;
						changeZoom(event, increment, img, aperture, 1.1);
						//setImgSize(img, increment);
						//fitImagetoAperture(img, aperture);
					});
					var imgRatio = img.width() / img.height();
					aperture.attr('data-ratio', imgRatio);

					fitImagetoAperture(img, aperture);
				}
				reader.readAsDataURL(value);
			});
		}

		var setImgSize = function (img, increment) {
			var top = parseInt(img.css('top'));
			var left = parseInt(img.css('left'));
			var height = parseInt(img.css('height'));
			var width = parseInt(img.css('Width'));
			height += increment;
			width += increment;
			var parentWidth = img.parent().width();
			var parentHeight = img.parent().height();
			if (height < parentHeight) {
				height = parentHeight;
				top = 0;
			} else {
				if (height - Math.abs(top) < parentHeight) {
					top = (height - parentHeight) * -1;
				} else {
					top = (Math.abs(top) + increment / 2) * -1;
				}
				top = top > 0 ? 0 : top;
			}
			if (width < parentWidth) {
				width = parentWidth;
				left = 0;
			} else {
				if (width - Math.abs(left) < parentWidth) {
					left = (width - parentWidth) * -1;
				} else {
					left = (Math.abs(left) + increment / 2) * -1;
				}
				left = left > 0 ? 0 : left;
			}
			img.css('left', left + 'px');
			img.css('top', top + 'px');
			img.css('width', width + 'px');
			img.css('height', height + 'px');
		}

		var changeZoom = function (event, delta, img, $imageSlot, customfactor) {
			var zoomFactor = customfactor ? Math.abs(customfactor) : this.options.zoomFactor;
			var image = $(img);
			var imageOffset = image.offset();
			var slot = image.parent();
			var slotNumber = parseInt(slot.attr('index'), 10);
			var imageParentOffset = image.parent().offset();
			var mouseviewportX = event.pageX - imageParentOffset.left;
			var mouseviewportY = event.pageY - imageParentOffset.top;
			var scaledImageX;
			var scaledImageY;
			var scaledImageTop;
			var scaledImageLeft;
			var viewportHeight = image.parent().height();
			var viewportWidth = image.parent().width();
			var imageX = event.pageX - imageOffset.left;
			var imageY = event.pageY - imageOffset.top;

			var currentZoom = parseFloat(image.attr('zoomfactor'));

			if (delta > 0) {
				if (!$imageSlot.hasClass('warning') /*&& currentZoom < zoomFactor * 10*/) {
					scaledImageX = imageX * zoomFactor;
					scaledImageY = imageY * zoomFactor;
					scaledImageTop = -1 * (scaledImageY - mouseviewportY);
					scaledImageLeft = -1 * (scaledImageX - mouseviewportX);
					image.height(image.height() * zoomFactor);
					image.width(image.width() * zoomFactor);
					image.css('top', scaledImageTop + "px");
					image.css('left', scaledImageLeft + "px");
					image.attr('zoomfactor', (currentZoom + zoomFactor));
				}
			} else {
				if (currentZoom > 0) {
					scaledImageX = imageX / zoomFactor;
					scaledImageY = imageY / zoomFactor;
					scaledImageTop = -1 * (scaledImageY - mouseviewportY);
					scaledImageLeft = -1 * (scaledImageX - mouseviewportX);
					if (scaledImageTop > 0)
						scaledImageTop = 0;
					if (scaledImageLeft > 0)
						scaledImageLeft = 0;

					var maxYoffset = (-1 * ((image.height() / zoomFactor) - viewportHeight)).toFixed(2);
					var maxXoffset = (-1 * ((image.width() / zoomFactor) - viewportWidth)).toFixed(2);

					if (scaledImageTop < maxYoffset) {
						scaledImageTop = maxYoffset;
					}
					if (scaledImageLeft < maxXoffset) {
						scaledImageLeft = maxXoffset;
					}

					image.height(image.height() / zoomFactor);
					image.width(image.width() / zoomFactor);

					if (image.height() < slot.height() || image.width() < slot.width()) {
						//console.log('zoom out fault caused image reposition');
						//this._fitImage2Slot(image, slot, this.imageInfo[slotNumber]);
						image.attr('zoomfactor', '0');
					} else {
						image.css('top', scaledImageTop + "px");

						image.css('left', scaledImageLeft + "px");
						image.attr('zoomfactor', (currentZoom - zoomFactor));
					}
				}
			}
			return false;
		}

		var fitImagetoAperture = function (image, slot) {
			var slotHeight = slot.height();
			var slotWidth = slot.width();
			var imageHeight = image.height();
			var imageWidth = image.width();

			var offset;
			var height2widthratio = imageHeight / imageWidth;
			var heightRatio = imageHeight / slotHeight;
			var widthRatio = imageWidth / slotWidth;
			if (heightRatio < widthRatio) {
				//by height
				image.height(slotHeight);
				image.width(slotHeight / height2widthratio);
				offset = (image.width() - slotWidth) / 2 * -1;
				image.css('left', offset + 'px');
				image.css('top', '0px');
			} else {
				//by width
				image.width(slotWidth);
				image.height(slotWidth * height2widthratio);
				offset = (image.height() - slotHeight) / 2 * -1;
				image.css('top', offset + 'px');
				image.css('left', '0px');
			}
		}
	}
})(jQuery)