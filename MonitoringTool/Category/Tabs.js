var monitoringTool = monitoringTool || {};

monitoringTool.categoryTabs = function () {
    var renderTabs = function () {
        $("#categoryTabs").tabs();
    };

    return {
        renderTabs: renderTabs
    };
};