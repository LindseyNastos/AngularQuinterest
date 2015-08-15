(function () {

    angular.module('QuinterestApp').factory('pinService', function ($resource) {

        var Pin = $resource('/api/pins/:id');

        var _pinList = function () {
            return Pin.query();
        };

        var _save = function (pin) {
            return Pin.save(pin);
        };

        var _get = function (id) {
            return Pin.get({ id: id });
        };

        var _remove = function (id) {
            return Pin.remove({ id: id });
        };



        return {
            pinList: _pinList,
            save: _save,
            get: _get,
            remove: _remove
        };

    });



    angular.module('QuinterestApp').factory('boardService', function ($resource) {

        var Board = $resource('/api/boards/:id');

        var Pins = $resource('/api/user/:id')

        var _boardList = function () {
            return Board.query();
        };

        var _save = function (board) {
            return Board.save(board);
        };

        var _get = function (id) {
            return Board.get({ id: id });
        };

        var _remove = function (id) {
            return Board.remove({ id: id });
        };

        var _getPins = function (id) {
            return Pins.query({ id: id });
        };

        return {
            boardList: _boardList,
            save: _save,
            get: _get,
            remove: _remove,
            getPins: _getPins
        };

    });

    angular.module('QuinterestApp').factory('accountService', function ($http, $resource) {

        var _userLogin = function (login) {
            var data = "grant_type=password&username=" + login.userName + "&password=" + login.password;

            return $http.post('/Token', data,
            {
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            })
        };

        var _userRegistration = function (registrationInfo) {
            var register = $resource('api/Account/Register');
            register.save(registrationInfo);

            return 
        };

        return {
            userLogin: _userLogin,
            userRegistration: _userRegistration
        }

    });


})();