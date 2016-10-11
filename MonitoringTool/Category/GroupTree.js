$(function () {
    $("#groupTree").on('changed.jstree', function (e, data) {
        var selectedItems = []; 
        $(data.selected).each(function () {            
            selectedItems.push({ id: this.valueOf(), name: data.instance.get_node(this).text });
        });

        var categoriesData = JSON.stringify({ 'categoriesData': selectedItems });

        $.ajax({
            url: monitoringTool.categoriesTabsActionUrl,
            type: 'POST',
            data: categoriesData,
            dataType: 'html',
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                $("#categoryTabsWrapper").html(data);
                monitoringTool.categoryTabs().renderTabs();
                monitoringTool.chartRenderer().renderCharts();
            },
            error: function (data) {
                $("#categoriesTabsWrapper").html(data.responseText);
            }
        });
    })
        .jstree({
        core: {
            themes: {
                name: "default",
                dots: false,
                icons: false
            },
            data: {
                type: "GET",
                url: "api/CategoryApi/GetCategories",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    $(data).each(function () {
                        return { "id": data };
                    });
                }
            },
        },
        plugins: ["checkbox"],
        checkbox: {
            keep_selected_style: false
        },
    });
});