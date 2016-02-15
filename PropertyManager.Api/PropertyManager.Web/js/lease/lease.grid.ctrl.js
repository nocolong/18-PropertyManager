﻿angular.module('app').controller('LeaseGridController', function ($scope, LeaseResource) {

    function activate() {
        $scope.leases = LeaseResource.query();
    }
    activate();

    $scope.removeLease = function (lease) {
        lease.$remove(function () {
            activate();
        });
    };

});