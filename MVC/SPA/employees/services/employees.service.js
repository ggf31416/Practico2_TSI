(function () {
    'use strict';
    angular.module('tsi.employee').service('employeesService', ["$http", "$q", employeeService]);
    baseUri = "http://localhost:50718/api/employee";


    function employeeService($http, $q) { }


    function getEmployee(id) {
        $http.get(baseUri+"/"+id).then(function (response) {
             this.data = response.data;
        });
    }

    function getEmployees() {
        $http.get(baseUri).then(function (response) {
            this.data = response.data;
        });
    }
})();