export function showDatepicker(domRef, dotnetObjRef, dateInput) {
    if (!domRef) 
        return
    
    let date = dateInput;
    
    $(domRef).daterangepicker({
        alwaysShowCalendars: true,
        singleDatePicker: true,
        showCustomRangeLabel: false,
        opens: "left",
        autoUpdateInput: false,
        locale: {
            format: 'YYYY-MM-DD' // for compatible with HTML
        }
    }, async function(start, end, label){
        // await state.DotnetObj.invokeMethodAsync("SetDatetimeValue", start, end, label)
    });

    $(domRef).on('apply.daterangepicker', async (ev, picker) => {
        if (!picker.startDate || !picker.endDate)
            return;
        await dotnetObjRef.invokeMethodAsync("SetDatetimeValue", picker.startDate, picker.endDate, picker.customRangeLabel);
    })
}


