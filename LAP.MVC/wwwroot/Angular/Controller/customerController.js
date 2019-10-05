angular.module("AppModule", ["HelperService", "CoreService"])
    .controller("customerCtrl", function ($scope, helperSrv, coreSrv, LapEnum, $filter) {
        $scope.customerPopup = function () {
            $("input[Name=StName]").val("");
            $("input[Name=InCustomerId]").val(0);
            $("textarea[Name=StDescription]").val("");
            $("input[Name=FlBalance]").val(0);

            $("#modalCustomer").modal('show');
        };
        $("#customerCreateModel").click(function () {
            var formData = helperSrv.convertFormJson($('#customerFormId').serializeArray());
            if (helperSrv.isNotEmpty(formData.StDescription)) {
                formData.FlBalance = formData.FlBalance.replace("₺", "");
                coreSrv.create(formData, '/musteri/kaydet').then(function (result) {
                    if (result.success) {
                        $("#modalCustomer").modal('hide');
                        getAllList();
                    }
                }, function (error) { });
            } else {
                helperSrv.notification("Lütfen Açıklama Giriniz.", "Uyarı", LapEnum.NotificaitonType[3]);
            }
        });
        $("#DeleteModel").click(function () {
            var id = $("#DeleteModel").attr("delete-model-id");
            coreSrv.delete(id, "/musteri/sil").then(function (result) {
                if (result.success) {
                    getAllList();
                    $("#ModalDelete").modal('hide');
                }
            });
        });

        $("input:radio[name=wcfBllLayer]").on("change", function () { getAllList(); });

        function getAllList() {
            coreSrv.getAll("/musteri/list/data?IsServis=" + $("input:radio[name=wcfBllLayer]:checked").val()).then(function (result) {
                $(function () {
                    var dataGrid = $("#gridCustomerList").dxDataGrid({
                        dataSource: result,
                        columnsAutoWidth: true,
                        showBorders: true,
                        wordWrapEnabled: true,
                        remoteOperations: {
                            sorting: true,
                            paging: true
                        },
                        columnChooser: {
                            enabled: true,
                            mode: "select"
                        },
                        paging: {
                            pageSize: 10
                        },
                        pager: {
                            showPageSizeSelector: true,
                            allowedPageSizes: [10, 25, 50, 100]
                        },
                        filterRow: {
                            visible: true,
                            applyFilter: "auto"
                        },
                        export: {
                            enabled: true
                        },
                        searchPanel: {
                            visible: true,
                            width: 300,
                            placeholder: "Search..."
                        },
                        headerFilter: {
                            visible: true
                        },
                        columns: [{
                            dataField: "inCustomerId", caption: "İşlem",
                            visible: true,
                            fixed: true,
                            allowSearch: false,
                            alignment: "center",
                            allowFiltering: false,
                            allowSorting: false,
                            width: 100,
                            minWidth: 75,
                            headerFilter: {
                                visible: false
                            },
                            cellTemplate: function (element, info) {
                                $('<a style="color:white; padding:7px !important;"></a>').addClass('btn btn-danger btn-xs btn-sm pull-right  ml-3 fa fa-trash')
                                    .text("")
                                    .on('dxclick', function () {
                                        $("#DeleteModMes").html("[ " + info.data.stName + " ] </br>  müşterisi silinsin mi ? ");
                                        $("#DeleteModel").attr("delete-model-id", info.data.inCustomerId);
                                        $("#ModalDelete").modal('show');
                                    })
                                    .appendTo(element);
                                $('<a style="color:white; padding:7px !important;"></a>').addClass('btn btn-success btn-xs btn-sm pull-right  ml-3 fa fa-pencil-square-o')
                                    .text('')
                                    .on('dxclick', function () {
                                        $("input[Name=StName]").val(info.data.stName);
                                        $("input[Name=InCustomerId]").val(info.data.inCustomerId);
                                        $("textarea[Name=StDescription]").val(info.data.stDescription);
                                        $("input[Name=FlBalance]").val(info.data.flBalance.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,') + " ₺");

                                        $("#modalCustomer").modal('show');
                                    }).appendTo(element);
                            }
                        }, {
                            dataField: "stName", caption: "Isim",
                            width: 100,
                            minWidth: 250,
                            alignment: "left",
                            headerFilter: {
                                allowSearch: true
                            },
                            cellTemplate: function (element, info) {
                                element.append((info.rowIndex + 1) + ". " + info.data.stName);
                            }
                        }, {
                            dataField: "flBalance", caption: "Bakiye",
                            alignment: "left",
                            cellTemplate: function (container, options) {
                                container.append(options.data.flBalance.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,') + " ₺");
                            },
                            width: 200,
                            minWidth: 125,
                            editorOptions: {
                                showClearButton: true
                            },
                            headerFilter: {
                                visible: false,
                                allowSearch: true
                            }
                        }, {
                            dataField: "stDescription", caption: "Açıklama",
                            visible: true,
                            minWidth: 150,
                            headerFilter: {
                                allowSearch: true
                            },
                            cellTemplate: function (element, info) {
                                $('<a ></a>').addClass('ml-3')
                                    .text(info.data.stDescription)
                                    .on('dxclick', function () {
                                        $("#desModel").text(info.data.stDescription);
                                        $("#modalDescription").modal('show');
                                    })
                                    .appendTo(element);
                            }
                        }],
                        summary: {
                            totalItems: [{
                                column: "flBalance",
                                summaryType: "sum",
                                alignment: "left",
                                customizeText: function (e) {
                                    return "Σ =" + e.value.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,') + " ₺";
                                }
                            }, {
                                column: "stName",
                                summaryType: "count",
                                alignment: "left",
                                customizeText: function (e) {
                                    return "Σ =" + e.value.toLocaleString() + " tane";
                                }
                            }]
                        },
                        onCellPrepared: e => { },
                        onExporting: e => { }
                    }).dxDataGrid('instance');
                });
            }, function (error) { });
        }
        getAllList();
    });
