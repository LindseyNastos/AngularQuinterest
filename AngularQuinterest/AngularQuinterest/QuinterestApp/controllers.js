(function () {

    var app = angular.module('QuinterestApp');

    //PINS

    app.controller('PinIndexController', ['$http', '$resource', '$location', 'pinService', 'accountService', '$modal', function ($http, $resource, $location, pinService, accountService, $modal) {
        var self = this;

        

        //Pin List
        self.getPins = function () {
            self.pins = pinService.pinList();
        };

        

        self.pins = [];
        
        self.userLogin = function () {
            accountService.userLogin(self.login)
                .success(function (result) {
                    sessionStorage.setItem("access_token", result.access_token);
                    $http.defaults.headers.common['Authorization'] = 'bearer ' + sessionStorage.getItem("access_token");
                    self.getPins();
                }).error(function () {
                self.loginErrorMessage = "The user name/password is incorrect."
            });
        };


        self.register = {};

        self.registerUser = function () {
            accountService.userRegistration(self.register);
                    var data = {};
                    data.userName = self.register.email;
                    data.password = self.register.password;
                    accountService.userLogin(data)
                        .success(function (result) {
                            sessionStorage.setItem("access_token", result.access_token);
                            $http.defaults.headers.common['Authorization'] = 'bearer ' + sessionStorage.getItem("access_token");
                            self.getPins();
            });
        };

        self.isLoggedIn = function () {
            return sessionStorage.getItem("access_token");

        };

        self.logOut = function () {
            sessionStorage.removeItem("access_token");

        };


        //Profile Button
        self.profile = function () {
            $location.path('/profile')
        };

        //Details Button
        self.details = function (id) {
            $location.path('/pinDetails/' + id);
        };

        

        //Create Pin
        self.showCreateModal = function () {
            $modal.open({
                templateUrl: '/ngViews/modals/createPinModal.html',
                controller: 'CreatePinModal',
                controllerAs: 'modal'
            }).result.then(function () {
                self.getPins();
            });
        };

        //Pin It
        self.showPinItModal = function (id) {
            $modal.open({
                templateUrl: '/ngViews/modals/pinItModal.html',
                controller: 'PinItModal',
                controllerAs: 'modal',
                resolve: {
                    id: function () {
                        return id;
                    }
                }
            });
        };

        self.getPins();

    }]);


    app.controller('PinDetailsController', ['$location', '$routeParams', 'pinService', '$modal', function ($location, $routeParams, pinService, $modal) {
        var self = this;

        self.pin = pinService.get($routeParams.id);

        //Pin It
        self.showPinItModal = function (id) {
            $modal.open({
                templateUrl: '/ngViews/modals/pinItModal.html',
                controller: 'PinItModal',
                controllerAs: 'modal',
                resolve: {
                    id: function () {
                        return id;
                    }
                }
            });
        };

        //Edit Pin
        self.showEditModal = function (id) {
            $modal.open({
                templateUrl: '/ngViews/modals/createPinModal.html',
                controller: 'EditPinModal',
                controllerAs: 'modal',
                resolve: {
                    id: function () {
                        return id;
                    }
                }
            }).result.then(function () {
                self.pin = pinService.get(id);
            });
        };

        //Delete Pin
        self.showRemoveModal = function (id) {
            $modal.open({
                templateUrl: '/ngViews/modals/removePinModal.html',
                controller: 'DeletePinModal',
                controllerAs: 'modal',
                resolve: {
                    id: function () {
                        return id;
                    }
                }
            }).result.then(function () {
                $location.path('/');
            });
        };

    }]);


    app.controller('PinItModal', ['$modal', 'id', '$routeParams', '$modalInstance', 'pinService', 'boardService', function ($modal, id, $routeParams, $modalInstance, pinService, boardService) {
        var self = this;

        //Get Pin
        self.pin = pinService.get(id);

        //Board List
        self.boards = boardService.boardList();


        self.getBoards = function () {
            self.boards = boardService.boardList();

        };

        
        self.showCreateBoardModal = function () {
            $modal.open({
                templateUrl: '/ngViews/modals/createBoardModal.html',
                controller: 'CreateBoardModal',
                controllerAs: 'modal'
            }).result.then(function () {
                self.getBoards();
            });
        };

        //self.clone = function (id) {
        //    pinService.save(self.pin).$promise.then(function () {
        //        $modalInstance.close();
        //    })
        //};

        self.exit = function () {
            $modalInstance.dismiss();
        };

    }]);


    app.controller('CreatePinModal', function ($modalInstance, boardService, pinService) {
        var self = this;

        self.boards = boardService.boardList();


        self.save = function () {

            pinService.save(self.pin).$promise.then(function () {
                $modalInstance.close();
            })
        };

        self.exit = function () {
            $modalInstance.close();
        };

    });


    app.controller('EditPinModal', function ($modalInstance, boardService, pinService, id) { 
        var self = this;

        self.pin = pinService.get(id);

        self.boards = boardService.boardList();

        self.save = function () {
            pinService.save(self.pin).$promise.then(function () {
                $modalInstance.close();
            });
        };
    
    });
        

    app.controller('DeletePinModal', function ($modalInstance, pinService, id) {
        var self = this;

        self.remove = function () {
            pinService.remove(id).$promise.then(function () {
                $modalInstance.close();
            });
        };

        self.exit = function () {
            $modalInstance.dismiss();
        };

    });


   
    //BOARDS

    app.controller('BoardIndexController', function ($modal, boardService) {
        var self = this;

        var boards = [];

        //Board List
        self.getBoards = function () {
            self.boards = boardService.boardList();
        };

        var user = {};

        self.userProfile = function () {
            self.user = boardService.profile();
        };

        //Create Board
        self.showCreateBoardModal = function () {
            $modal.open({
                templateUrl: '/ngViews/modals/createBoardModal.html',
                controller: 'CreateBoardModal',
                controllerAs: 'modal'
            }).result.then(function () {
                self.userProfile();
                self.getBoards();
            });
        };

        //Create Pin
        self.showCreatePinModal = function () {
            $modal.open({
                templateUrl: 'ngViews/modals/createPinModal.html',
                controller: 'CreatePinModal',
                controllerAs: 'modal'
            }).result.then(function () {
                self.userProfile();
                self.getBoards();
            });
        };

        self.getBoards();
        self.userProfile();
        
    });


    app.controller('BoardDetailsController', function ($location, $routeParams, $modal, boardService) {
        var self = this;

        self.pins = boardService.getPins($routeParams.id);

        self.board = boardService.get($routeParams.id);
       
        self.details = function (id) {
            $location.path('/pinDetails/' + id);
        };

        //Need to get pins on that board
        self.board = boardService.get($routeParams.id);

        //Create Pin
        self.showCreatePinModal = function () {
            $modal.open({
                templateUrl: 'ngViews/modals/createPinModal.html',
                controller: 'CreatePinModal',
                controllerAs: 'modal'
            }).result.then(function () {
                self.pins = boardService.getPins($routeParams.id);
                self.board = boardService.get($routeParams.id);
            });
        };

        //Edit Board
        self.showEditBoardModal = function (id) {
            $modal.open({
                templateUrl: 'ngViews/modals/createBoardModal.html',
                controller: 'EditBoardModal',
                controllerAs: 'modal',
                resolve: {
                    id: function () {
                        return $routeParams.id;
                    }
                }
            }).result.then(function () {
                self.board = boardService.get($routeParams.id); 
            });
        };

        //Delete Board
        self.showRemoveBoardModal = function (id) {
            $modal.open({
                templateUrl: 'ngViews/modals/removeBoardModal.html',
                controller: 'DeleteBoardModal',
                controllerAs: 'modal',
                resolve: {
                    id: function () {
                        return $routeParams.id;
                    }
                }
            }).result.then(function () {
                $location.path('/profile');
            });
        };

    });


    app.controller('CreateBoardModal', function ($modalInstance, boardService) {
        var self = this;

        self.save = function () {
            boardService.save(self.board).$promise.then(function () {
                $modalInstance.close();
            });
        };
    });


    app.controller('EditBoardModal', function ($modalInstance, id, boardService) {
        var self = this;

        self.board = boardService.get(id);

        self.save = function () {
            boardService.save(self.board).$promise.then(function () {
                $modalInstance.close();
            });
        };
    });


    app.controller('DeleteBoardModal', function ($modalInstance, boardService, id) {
        var self = this;

        self.remove = function () {
            boardService.remove(id).$promise.then(function () {
                $modalInstance.close()
            });
        };

        self.exit = function () {
            $modalInstance.dismiss();
        };

    });


})();