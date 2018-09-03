
    angular.module('starter.controllers', ['swipe'])

    /*****************
    * MAIN CONTROLLER
    ******************/
    .controller('AppCtrl', function ($scope, $state, logService) {

        logService.add(0, 'index.html', 0);

    })

    /************************
     * LOGIN FORM CONTROLLER
     ************************/
    .controller('LoginCtrl', function ($scope,
        $state,
        $ionicPopup,
        $ionicSideMenuDelegate,
        userService,
        logService) {

        $ionicSideMenuDelegate.canDragContent(false);

        $scope.currentUser = userService.getCurrent();
        logService.add($scope.currentUser.Id, 'login.html', 0);

        $scope.doLogin = function () {

            userService.login($scope.currentUser.Email, $scope.currentUser.Password).then(
                function (response) {

                    $scope.currentUser = response.data;

                    //login
                    logService.add($scope.currentUser.Id, 'login.html', 1);

                    $state.go('app.home');

                },
                function (response) { // Error callback
                    // Handle error state

                    //unauthorized
                    logService.add($scope.currentUser.Id, 'login.html', 6);

                    $ionicPopup.alert({
                        title: 'Пользователь не найден',
                        template: 'Попробуйте еще раз или обратитесь в службу поддержки.'
                    });
                }

            );


        };

        $scope.doRegistration = function () {
            $state.go('app.registration');
        };

        $scope.doRestorePassword = function () {
            $state.go('app.restorepassword');
        };

    })

        /************************
         * REGISTRATION FORM CONTROLLER
         ************************/
        .controller('RegistrationCtrl', function ($scope,
            $state,
            $ionicPopup,
            $ionicSideMenuDelegate,
            userService,
            logService) {

            $ionicSideMenuDelegate.canDragContent(false);

            $scope.currentUser = userService.getCurrent();
            logService.add($scope.currentUser.Id, 'login.html', 0);

            $scope.doLogin = function () {

                userService.login($scope.currentUser.Email, $scope.currentUser.Password).then(
                    function (response) {

                        $scope.currentUser = response.data;

                        //login
                        logService.add($scope.currentUser.Id, 'login.html', 1);

                        $state.go('app.home');

                    },
                    function (response) { // Error callback
                        // Handle error state

                        //unauthorized
                        logService.add($scope.currentUser.Id, 'login.html', 6);

                        $ionicPopup.alert({
                            title: 'Пользователь не найден',
                            template: 'Попробуйте еще раз или обратитесь в службу поддержки.'
                        });
                    }

                );


            };

            $scope.doRegistration = function () {
                $state.go('app.registration');
            };

            $scope.doRestorePassword = function () {
                $state.go('app.restorepassword');
            };

        })

     /************************
     * RESTORE PASSWORD FORM CONTROLLER
     ************************/
        .controller('RestorePasswordCtrl', function ($scope,
            $state,
            $ionicPopup,
            $ionicSideMenuDelegate,
            userService,
            logService) {

            $ionicSideMenuDelegate.canDragContent(false);

            $scope.currentUser = userService.getCurrent();
            logService.add($scope.currentUser.Id, 'login.html', 0);

            $scope.doLogin = function () {

                userService.login($scope.currentUser.Email, $scope.currentUser.Password).then(
                    function (response) {

                        $scope.currentUser = response.data;

                        //login
                        logService.add($scope.currentUser.Id, 'login.html', 1);

                        $state.go('app.home');

                    },
                    function (response) { // Error callback
                        // Handle error state

                        //unauthorized
                        logService.add($scope.currentUser.Id, 'login.html', 6);

                        $ionicPopup.alert({
                            title: 'Пользователь не найден',
                            template: 'Попробуйте еще раз или обратитесь в службу поддержки.'
                        });
                    }

                );


            };

            $scope.doRegistration = function () {
                $state.go('app.registration');
            };

            $scope.doRestorePassword = function () {
                $state.go('app.restorepassword');
            };

        })
    /*************
    * ONBOARDING CONTROLLER
    *************/
    .controller('OnboardingCtrl', function ($scope, $stateParams, $ionicLoading, $timeout, $state, ticketService, userService, logService) {

        $scope.currentUser = userService.getCurrent();

        $scope.btnClick = function () {

        };

    })

    /*****************
    * HOME CONTROLLER
    *****************/
        .controller('HomeCtrl', function ($scope, $state, $stateParams, $interval, $ionicModal, $ionicPopup, tripsService, userService, logService, appsettingsService, $sce) {

        $scope.currentUser = userService.getCurrent();

        logService.add($scope.currentUser.Id, 'home.html', 0);

            $scope.trips = tripsService.getData();
        if ($scope.trips === undefined) {
            $ionicPopup.alert({
                title: 'Не удалось получить данные!',
                template: 'Для работы приложения необходимо подключение к интернет.'
            });
        }

        $scope.addTrip = function () {

            logService.add($scope.currentUser.Id, 'home.html', 5);

        };

     })

    /****************
    * COUNTRIES CONTROLLER
    ****************/
        .controller('CountriesCtrl', function ($scope, $state, $ionicPopup, $stateParams, tripsService, userService, logService) {

        $scope.currentUser = userService.getCurrent();
        logService.add($scope.currentUser.Id, 'search.html', 0);

        //$scope.trips = tripsService.getData();

        //$scope.getData = function (str) {

        //  deviceService.findByName(str).then(function (result) {
        //    $scope.devices = result;

        //    logService.add($scope.currentUser.Id, 'search.html', 4);

        //  });
        //};

    })
    /****************
    * TRIPS CONTROLLER
    ****************/
        .controller('TripsCtrl', function ($scope, $state, $ionicPopup, $stateParams, tripsService, userService, logService) {

        $scope.currentUser = userService.getCurrent();
        logService.add($scope.currentUser.Id, 'search.html', 0);

        //$scope.trips = tripsService.getData();

        //$scope.getData = function (str) {

        //  deviceService.findByName(str).then(function (result) {
        //    $scope.devices = result;

        //    logService.add($scope.currentUser.Id, 'search.html', 4);

        //  });
        //};

    })

    /*************
    * PROFILE CONTROLLER
    *************/
    .controller('ProfileCtrl', function (userService, $scope, $stateParams) {

        $scope.currentUser = userService.getCurrent();

    })
    /*************
    * SETTINGS CONTROLLER
    *************/
        .controller('SettingsCtrl', function (userService, userTrackingScheduleService, $scope, $stateParams) {

        //$scope.currentUser = userService.getCurrent();

    })
    /*************
    * ABOUT APP CONTROLLER
    *************/
    .controller('AboutCtrl', function (appsettingsService, $scope, $stateParams) {

        appsettingsService.findByKey(SETTINGS_KEY_CONTACT_EMAIL).then(function (list) {
            if (list !== undefined && list.length > 0)
                $scope.helpdeskEmail = list[0].Value;
        });

        appsettingsService.findByKey(SETTINGS_KEY_CONTACT_PHONE).then(function (list) {
            if (list !== undefined && list.length > 0)
                $scope.helpdeskPhone = list[0].Value;
        });

        appsettingsService.findByKey(SETTINGS_KEY_CONTACT_URL).then(function (list) {
            if (list !== undefined && list.length > 0)
                $scope.helpdeskUrl = list[0].Value;
        });

    });

