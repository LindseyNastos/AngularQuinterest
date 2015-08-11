(function () {

    var app = angular.module('QuinterestApp');

    //PINS

    app.controller('PinIndexController', ['pinService', '$modal', function (pinService, $modal) {
        var self = this;
        self.pins = [];

        //Pin List
        self.getPins = function () {
            self.pins = pinService.pinList();
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



        self.getPins();

    }]);


    app.controller('PinDetailsController', ['id', 'pinService', '$modal', function (id, pinService, $modal) {
        var self = this;

        //Pin It
        self.showPinItModal = function (id) {
            $modal.open({
                templateUrl: '/ngViews/modals/createPinModal.html',
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
            });
        };

    }]);


    app.controller('PinItModal', ['id', '$modalInstance', 'pinService', 'boardService', function (id, $modalInstance, pinService, boardService) {
        var self = this;
        self.boards = [];

        //Board List
        self.getBoards = function () {
            self.boards = boardService.boardList();
        };

        //self.clone = function (id) {
        //    pinService.save(self.pin).$promise.then(function () {
        //        $modalInstance.close();
        //    })
        //};

        self.exit = function () {
            $modalInstance.close();
        };

    }]);


    app.controller('CreatePinModal', function ($modalInstance, pinService) {
        var self = this;

        self.save = function () {
            pinService.save(self.pin).$promise.then(function () {
                $modalInstance.close();
            })
        };

        self.exit = function () {
            $modalInstance.close();
        };

    });


    app.controller('EditPinModal', function ($modalInstance, pinService, id) { 
        var self = this;

        self.pin = pinService.get(id);

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
        self.boards = [];

        //Board List
        self.getBoards = function () {
            self.boards = boardService.boardList();
        };

        //Create Board
        self.showBoardModal = function () {
            $modal.open({
                templateUrl: '/ngViews/modals/createBoardModal.html',
                controller: 'CreateBoardModal',
                controllerAs: 'modal'
            }).result.then(function () {
                self.getBoards();
            });
        };

        //Create Pin
        self.showPinModal = function () {
            $modal.open({
                templateUrl: 'ngViews/modals/createPinModal.html',
                controller: 'CreatePinModal',
                controllerAs: 'modal'
            }).result.then(function () {
                self.getPins();
            });
        };

        self.getBoards();
    });


    app.controller('BoardDetailsController', function (id, $modal, boardService) {
        var self = this;

        self.pins = [];
        //Need to get pins on that board


        //Create Board
        self.showCreateModal = function () {
            $modal.open({
                templateUrl: 'ngViews/modals/createBoardModal.html',
                controller: 'CreateBoardModal',
                controllerAs: 'modal'
            });
        };

        //Edit Board
        self.showEditModal = function (id) {
            $modal.open({
                templateUrl: 'ngViews/modals/createBoardModal.html',
                controller: 'EditBoardModal',
                controllerAs: 'modal',
                resolve: {
                    id: function () {
                        return id;
                    }
                }
            });
        };

        //Delete Board
        self.showRemoveModal = function (id) {
            $modal.open({
                templateUrl: 'ngViews/modals/removePinModal.html',
                controller: 'DeleteBoardModal',
                controllerAs: 'modal',
                resolve: {
                    id: function () {
                        return id;
                    }
                }
            });
        };

    });


    app.controller('CreateBoardModal', function ($modalInstance, boardService) {
        var self = this;

        self.board = boardService.get(id);

        self.save = function () {
            boardService.save(self.board).$promise.then(function () {
                $modalInstance.close();
            });
        };
    });


    app.controller('EditBoardModal', function ($modalInstance, id, boardService) {
        var self = this;

        self.save = function () {
            boardService.save(self.board).$promise.then(function () {
                $modalInstance.close();
            });
        };
    });


    app.controller('DeleteBoardModal', function ($modalInstance, id, boardService) {
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





    //LOGIN

    app.controller('AccountController', function ($http) {
        var self = this;

        self.login = function () {
            self.loginMessage = '';
            var data = "grant_type=password&username=" + self.login.email + "&password=" + self.login.password;

            $http.post('/Token', data,
            {
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).success(function (result) {
                self.login = null;
                $http.defaults.headers.common['Authorization'] = 'bearer ' + result.access_token;
                $http.get('/api/admin/isAdmin').success(function (isAdmin) {
                    sessionStorage.setItem('accessToken', result.access_token);
                    sessionStorage.setItem('isAdmin', isAdmin);
                })
            }).error(function () {
                self.loginMessage = 'Invalid user name/password';
            });
        };

        self.logout = function () {
            sessionStorage.removeItem('accessToken');
            sessionStorage.removeItem('isAdmin');
        };

        self.isAdmin = function () {
            return sessionStorage.getItem('isAdmin') === 'true';
        };

        self.isLoggedIn = function () {
            return sessionStorage.getItem('accessToken') != undefined;
        };


    });




})();