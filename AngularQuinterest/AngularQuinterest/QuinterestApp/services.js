(function () {

    angular.module('QuinterestApp').factory('pinService', function ($resource, $http) {

        $http.defaults.headers.common['Authorization'] = 'bearer ' + sessionStorage.getItem("access_token");


        var Pin = $resource('/api/pins/:id');

        //var PinIt = $resource('/api/user/post?pinId=' + pinId + '&boardId=' + boardId);

        //var PinIt = $resource('/api/user/post?pinId=pinId&boardId=boardId');

        var PinIt = $resource('/api/user');

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

        var _clone = function (pinId, boardId) {
            var data = {};
            data.pinId = pinId;
            data.boardId = boardId;

            return PinIt.save(data)
        };

        return {
            pinList: _pinList,
            save: _save,
            get: _get,
            remove: _remove,
            clone: _clone
        };
    });



    angular.module('QuinterestApp').factory('boardService', function ($resource, $http) {

        $http.defaults.headers.common['Authorization'] = 'bearer ' + sessionStorage.getItem("access_token");

        var User = $resource('/api/user/:id')

        var Board = $resource('/api/boards/:id');

        var Pins = $resource('/api/user/:id')

        var _profile = function () {
            return User.get();
        };

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
            profile: _profile,
            boardList: _boardList,
            save: _save,
            get: _get,
            remove: _remove,
            getPins: _getPins
        };
    });

    angular.module('QuinterestApp').factory('accountService', function ($http, $resource) {

        var _userInfo = {};

        var _setUserInfo = function (obj) {
            _userInfo = obj;
        };

        var _getUserInfo = function () {
            return _userInfo;
        };

        var _userLogin = function (login) {
            var data = "grant_type=password&username=" + login.userName + "&password=" + login.password;

            return $http.post('/Token', data,
            {
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            })
        };

        var _userRegistration = function (registrationInfo) {
            var register = $resource('api/Account/Register');
            return register.save(registrationInfo);
        };

        return {
            userLogin: _userLogin,
            userRegistration: _userRegistration,
            getUserInfo: _getUserInfo,
            setUserInfo: _setUserInfo
        }
    });
})();