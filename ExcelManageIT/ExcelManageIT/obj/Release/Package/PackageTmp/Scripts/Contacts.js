$("#contactGrid").kendoGrid({
    dataSource: {
        type: "odata",
        transport: {
            read: "//demos.telerik.com/kendo-ui/service/Northwind.svc/Customers"
        },
        pageSize: 10
    },
    height: 550,
    groupable: true,
    sortable: true,
    pageable: {
        refresh: true,
        pageSizes: true,
        buttonCount: 5
    },
    columns: [{
        template: "<div class='customer-photo'" +
                        "style='background-image: url(../content/web/Customers/#:data.CustomerID#.jpg);'></div>" +
                    "<div class='customer-name'>#: ContactName #</div>",
        field: "ContactName",
        title: "Contact Name",
        width: 150,
        locked: true,
        lockable: false,
    }, {
        field: "ContactTitle",
        title: "Contact Title",
        width:150
    }, {
        field: "CompanyName",
        title: "Company Name",
        width: 150
    }, {
        field: "Country",
        width: 150
    }]
});