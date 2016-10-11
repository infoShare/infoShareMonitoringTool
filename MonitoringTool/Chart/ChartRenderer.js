var monitoringTool = monitoringTool || {};

monitoringTool.chartRenderer = function () {
    var renderCharts = function () {
        $("canvas[id^=category]").each(function () {
            var chartContext = $(this);
            $.ajax({
                url: "api/CategoryApi",
                type: "GET",
                contentType: "application/json; charset=utf-8",
                data: { category: this.accessKey },
                success: function (data) {
                    monitoringTool.categoryChart().renderChart(chartContext, data);
                }
            });
        });
    };

    return {
        renderCharts: renderCharts
    };
};