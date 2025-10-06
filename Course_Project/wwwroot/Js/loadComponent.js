function loadComponent(componentName) {
    $.get('Admin/Dashboard/Index?name=' + componentName, function (html) {
        $("#component-container").html(html);
    })
    
}