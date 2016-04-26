(function () {
    'use strict';
    // declara el controlador
    angular.module('tsi.employee').controller("employeesCtrl", ["employeesService" , employeesCtrl]);
    //angular.module('tsi.employee').controller("employeesCtrl", ['$scope', employeesCtrl]);


    function employeesCtrl(employeesService) {
        this._service = employeesService;
    }

    function getAllEmployees() {
       this._service.getEmployees();

    }


})();