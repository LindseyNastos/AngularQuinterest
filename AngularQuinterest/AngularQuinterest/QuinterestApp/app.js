(function () {
    angular.module('QuinterestApp', ['ngRoute', 'ngResource', 'ngAnimate', 'ui.bootstrap', 'infinite-scroll']).config(function ($routeProvider, $locationProvider) {
        $routeProvider
            .when('/', { //LIST OF PINS
                templateUrl: '/ngViews/pins/index.html',
                controller: 'PinIndexController',
                controllerAs: 'main'
            })
            .when('/pinDetails/:id', { //PIN EXPANDED
                templateUrl: '/ngViews/pins/pinDetails.html',
                controller: 'PinDetailsController',
                controllerAs: 'main'
            })
            .when('/profile', { //LIST OF BOARDS - PROFILE
                templateUrl: '/ngViews/boards/boardIndex.html',
                controller: 'BoardIndexController',
                controllerAs: 'main'
            })
            .when('/boardDetails/:id', { //BOARD EXPANDED - LIST OF PINS
                templateUrl: '/ngViews/boards/boardDetails.html',
                controller: 'BoardDetailsController',
                controllerAs: 'main'
            })
            .when('/registerLogin', {
                templateUrl: 'ngViews/registerAndLogin.html',
                controller: 'RegisterLoginController',
                controllerAs: 'main'
            })
            .when('/admin', {
                templateUrl: 'ngViews/profile/admin.html',
                controller: 'AdminController',
                controllerAs: 'main'
            })
            .otherwise({
                templateUrl: '/ngViews/notFound.html'
            });

        $locationProvider.html5Mode(true);

    });

})();