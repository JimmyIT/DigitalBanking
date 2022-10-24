$(function () {
	$("body").on("focus", ".daterangepicker-input", function () {
		$(this).daterangepicker({
			ranges: {
				Today: [moment(), moment()],
				Yesterday: [
					moment().subtract(1, "days"),
					moment().subtract(1, "days"),
				],
				"Last 7 Days": [moment().subtract(6, "days"), moment()],
				"Last 30 Days": [moment().subtract(29, "days"), moment()],
				"This Month": [
					moment().startOf("month"),
					moment().endOf("month"),
				],
				"Last Month": [
					moment().subtract(1, "month").startOf("month"),
					moment().subtract(1, "month").endOf("month"),
				],
			},
			alwaysShowCalendars: true,
			opens: "left",
		});
	});

	$("body").on("focus", ".datepicker-input", function () {
		$(this).daterangepicker({
			singleDatePicker: true,
			showCustomRangeLabel: false,
			alwaysShowCalendars: true,
			opens: "left",
		});
	});

	$("body").on("change", ".custom-file-input__upload", function (e) {
		$(this)
			.siblings(".custom-file-input__file")
			.find(".custom-file-input__file-name")
			.text(e.target.files[0].name);
		$(this)
			.closest(".custom-file-input")
			.addClass("custom-file-input--active");
	});

	$("body").on("click", ".custom-file-input__file-delete", function (e) {
		$(this)
			.closest(".custom-file-input")
			.removeClass("custom-file-input--active")
			.find(".custom-file-input__upload")
			.val("");
	});
});
