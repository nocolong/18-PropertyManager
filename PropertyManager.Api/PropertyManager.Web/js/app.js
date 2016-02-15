﻿angular.module('app', ['ngResource', 'ui.router']);

angular.module('app').value('apiUrl', 'http://localhost:53802/api');

angular.module('app').config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise("dashboard");

    $stateProvider.state('dashboard', {url: '/dashboard', templateUrl: '/templates/dashboard/dashboard.html', controller: 'DashboardController'})      
                  .state('property', { url: '/property', abstract: true, template: '<ui-view/>' })
                  .state('property.grid', { url: '/grid', templateUrl: '/templates/property/property.grid.html', controller: 'PropertyGridController' })
                  .state('property.detail', { url: '/detail/:id', templateUrl: '/templates/property/property.detail.html', controller: 'PropertyDetailController' })
                  .state('tenant', { url: '/tenant', abstract: true, template: '<ui-view/>' })
                  .state('tenant.grid', { url: '/grid', templateUrl: '/templates/tenant/tenant.grid.html', controller: 'TenantGridController' })
                  .state('tenant.detail', { url: '/detail/:id', templateUrl: '/templates/tenant/tenant.detail.html', controller: 'TenantDetailController' })
                  .state('lease', { url: '/lease', abstract: true, template: '<ui-view/>' })
                  .state('lease.grid', { url: '/grid', templateUrl: '/templates/lease/lease.grid.html', controller: 'LeaseGridController' })
                  .state('lease.detail', { url: '/detail/:id', templateUrl: '/templates/lease/lease.detail.html', controller: 'LeaseDetailController' })
                  .state('workorder', { url: '/workorder', abstract: true, template: '<ui-view/>' })
                  .state('workorder.grid', { url: '/grid', templateUrl: '/templates/workorder/workorder.grid.html', controller: 'WorkOrderGridController' })
                  .state('workorder.detail', { url: '/detail/:id', templateUrl: '/templates/workorder/workorder.detail.html', controller: 'WorkOrderDetailController' });







});