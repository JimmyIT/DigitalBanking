export function showDatepicker(domRef, dotnetObjRef, _startDate, _endDate, format) {
    if (!domRef) return
    
    let startDate = _startDate || Date.now();
    let endDate = _endDate || Date.now();
    let dateFormat = format ? format.toUpperCase() : "L";
    
    $(domRef).daterangepicker({
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
        singleDatePicker: false,
        showCustomRangeLabel: false,
        opens: "left",
        startDate: moment(startDate),
        endDate: moment(endDate),
        autoUpdateInput: false,
        locale: {
            format: dateFormat
        }
    }, async function(start, end, label) {
        // await state.DotnetObj.invokeMethodAsync("SetDatetimeValue", start, end, label);
    });
    
    $(domRef).on('apply.daterangepicker', async (ev, picker) => {
        if (!picker.startDate || !picker.endDate)
            return;
        await dotnetObjRef.invokeMethodAsync("SetDatetimeValue", picker.startDate, picker.endDate, picker.customRangeLabel);
    })
}
