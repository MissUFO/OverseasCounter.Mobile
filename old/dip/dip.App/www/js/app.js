// Ionic Starter App

// angular.module is a global place for creating, registering and retrieving Angular modules
// 'starter' is the name of this angular module example (also set in a <body> attribute in index.html)
// the 2nd parameter is an array of 'requires'
// 'starter.controllers' is found in controllers.js
angular.module('starter', ['ionic', 'starter.controllers'])

.run(function ($ionicPlatform, userTrackingScheduleService, tripsService, countriesService, appsettingsService, appService) {
  $ionicPlatform.ready(function () {

    //check data updates
    //userTrackingScheduleService.checkDataUpdates();
    //tripsService.checkDataUpdates();
    //countriesService.checkDataUpdates();
    appsettingsService.checkDataUpdates();

    // Hide the accessory bar by default (remove this to show the accessory bar above the keyboard
    // for form inputs)
      if (cordova.platformId === "ios" && window.cordova && window.cordova.plugins.Keyboard) {
      cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
      cordova.plugins.Keyboard.disableScroll(true);

    }
    if (window.StatusBar) {
      // org.apache.cordova.statusbar required
      StatusBar.styleDefault();
    }
  });
})
.config([
    '$compileProvider',
    function ($compileProvider) {
      $compileProvider.aHrefSanitizationWhitelist(/^\s*(https?|http|ftp|mailto|file|ghttps?|ms-appx|x-wmapp0):/);
    }
])
.config(function($stateProvider, $urlRouterProvider) {
  $stateProvider

  .state('app', {
    url: '/app',
    abstract: true,
    templateUrl: 'templates/menu.html',
    controller: 'AppCtrl'
  })

    .state('app.login', {
      url: '/login',
      views: {
        'menuContent': {
          templateUrl: 'templates/login.html',
          controller: 'LoginCtrl'
        }
      }
      })
      .state('app.registration', {
          url: '/registration',
          views: {
              'menuContent': {
                  templateUrl: 'templates/registration.html',
                  controller: 'RegistrationCtrl'
              }
          }
      })
      .state('app.restorepassword', {
          url: '/restorepassword',
          views: {
              'menuContent': {
                  templateUrl: 'templates/restorepassword.html',
                  controller: 'RestorePasswordCtrl'
              }
          }
      })
    .state('app.onboarding', {
        url: "/onboarding",
      views: {
        'menuContent': {
            templateUrl: "templates/onboarding.html",
          controller: 'OnboardingCtrl'
        }
      }
    })
  .state('app.home', {
    url: '/home',
    views: {
      'menuContent': {
          templateUrl: 'templates/home.html',
        controller: 'HomeCtrl'
      }
    }
  })
  .state('app.countries', {
      url: '/countries',
      views: {
        'menuContent': {
            templateUrl: 'templates/countries.html',
          controller: 'CountriesCtrl'
        }
      }
  })
    .state('app.trips', {
        url: '/trips',
      views: {
        'menuContent': {
         templateUrl: 'templates/trips.html',
         controller: 'TripsCtrl'
        }
      }
    })
  
    .state('app.about', {
      url: '/about',
      views: {
        'menuContent': {
          templateUrl: 'templates/about.html',
          controller: 'AboutCtrl'
        }
      }
    })
    .state('app.profile', {
      url: '/profile',
      views: {
        'menuContent': {
          templateUrl: 'templates/profile.html',
          controller: 'ProfileCtrl'
        }
      }
    })
    .state('app.settings', {
        url: '/settings',
      views: {
        'menuContent': {
            templateUrl: 'templates/settings.html',
          controller: 'SettingsCtrl'
        }
      }
    });

  // if none of the above states are matched, use this as the fallback
  $urlRouterProvider.otherwise('/app/login');
})

.factory('appService', function ($window) {
    return {
      setInitialRun : function (initial) {
        $window.localStorage["initialRun"] = (initial ? "true" : "false");
      },
      isInitialRun : function () {
        var value = $window.localStorage["initialRun"] || "true";
        return value === "true";
      }
    };
})
.factory('userService', function ($http) {

  var currentuser = { Id: 0, UserName: '', Password: '' };

    return {
      login: function (login, pwd) {
        
        return $http.get(API_URL + USER_LOGIN + login + '/' + pwd)
          .success(function(response) {

            currentuser = response;
            currentuser.Password = pwd;
            window.localStorage.setItem(USER_KEY, JSON.stringify(currentuser));

            return currentuser;
          })
          .error(function(e) {

            currentuser.Email = login;
            currentuser.Password = pwd;
            currentuser.Status = false;

            window.localStorage.setItem(USER_KEY, JSON.stringify(currentuser));

            return currentuser;
          });
      },
      logoff: function() {

        window.localStorage.setItem(USER_KEY, "");
        return true;
      },
      getCurrent: function() {

        if (window.localStorage.getItem(USER_KEY) !== undefined && window.localStorage.getItem(USER_KEY) !== 'undefined') {
          currentuser = JSON.parse(window.localStorage.getItem(USER_KEY));
        }

        return currentuser;
      },
      updateProfile: function () {

            window.localStorage.setItem(USER_KEY, "");
            return true;
      },
      getSchedule: function () {

            window.localStorage.setItem(USER_KEY, "");
            return true;
      },
      updateSchedule: function () {

            window.localStorage.setItem(USER_KEY, "");
            return true;
      },
    };
    })
.factory('userTrackingScheduleService', function ($http, $q) {

        var deviceData;

        return {
            checkDataUpdates: function () {

                var storageData = [];
                if (window.localStorage.getItem(USER_TRACKING_SCHEDULE_KEY) !== undefined &&
                    window.localStorage.getItem(USER_TRACKING_SCHEDULE_KEY) !== 'undefined')
                    storageData = JSON.parse(window.localStorage.getItem(USER_TRACKING_SCHEDULE_KEY));

                var serverData = [];
                $http.get(API_URL + USER_TRACKING_SCHEDULE_LIST).success(function (response) {

                    serverData = response;

                }).then(function () {

                    if (
                        //(storageData == null || storageData.length == 0) ||
                        (serverData !== null && serverData.length > 0)) {
                        deviceData = serverData;
                        window.localStorage.setItem(USER_TRACKING_SCHEDULE_KEY, JSON.stringify(deviceData));
                    } else
                        deviceData = storageData;

                    return deviceData;
                });

            },
            getData: function () {

                if (window.localStorage.getItem(USER_TRACKING_SCHEDULE_KEY) !== undefined &&
                    window.localStorage.getItem(USER_TRACKING_SCHEDULE_KEY) !== 'undefined') {

                    deviceData = JSON.parse(window.localStorage.getItem(USER_TRACKING_SCHEDULE_KEY));
                    return deviceData;

                } else {

                    return $http.get(API_URL + USER_TRACKING_SCHEDULE_LIST).success(function (response) {

                        deviceData = response;
                        window.localStorage.setItem(USER_TRACKING_SCHEDULE_KEY, JSON.stringify(deviceData));
                        return deviceData;

                    }).error(function (e) {
                        return deviceData;
                    });
                }
            },
            findById: function (id) {

                var deferred = $q.defer();

                if (window.localStorage.getItem(USER_TRACKING_SCHEDULE_KEY) !== undefined &&
                    window.localStorage.getItem(USER_TRACKING_SCHEDULE_KEY) !== 'undefined') {
                    deviceData = JSON.parse(window.localStorage.getItem(USER_TRACKING_SCHEDULE_KEY));
                } else {
                    deviceData = this.getData();
                }

                var results = deviceData.filter(function (element) {
                    var elementId = element.Id;
                    return elementId === id;
                });

                deferred.resolve(results);
                return deferred.promise;
            },
            findByName: function (searchKey) {

                var deferred = $q.defer();

                if (window.localStorage.getItem(USER_TRACKING_SCHEDULE_KEY) !== undefined &&
                    window.localStorage.getItem(USER_TRACKING_SCHEDULE_KEY) !== 'undefined') {
                    deviceData = JSON.parse(window.localStorage.getItem(USER_TRACKING_SCHEDULE_KEY));
                } else {
                    deviceData = this.getData();
                }

                var results = deviceData.filter(function (element) {
                    return element.Name.toLowerCase().indexOf(searchKey.toLowerCase()) > -1 ||
                        element.Model.toLowerCase().indexOf(searchKey.toLowerCase()) > -1;
                });

                deferred.resolve(results);
                return deferred.promise;
            }
        };
    })
.factory('tripsService', function ($http, $q) {

    var deviceData;

    return {
      checkDataUpdates: function() {

        var storageData = [];
        if (window.localStorage.getItem(TRIPS_KEY) !== undefined &&
            window.localStorage.getItem(TRIPS_KEY) !== 'undefined')
            storageData = JSON.parse(window.localStorage.getItem(TRIPS_KEY));

        var serverData = [];
          $http.get(API_URL + TRIPS_LIST).success(function(response) {

          serverData = response;

        }).then(function() {

          if (
            //(storageData == null || storageData.length == 0) ||
            (serverData !== null && serverData.length > 0)) {
            deviceData = serverData;
              window.localStorage.setItem(TRIPS_KEY, JSON.stringify(deviceData));
          } else
            deviceData = storageData;

          return deviceData;
        });

      },
      getData: function() {

          if (window.localStorage.getItem(TRIPS_KEY) !== undefined &&
              window.localStorage.getItem(TRIPS_KEY) !== 'undefined') {

              deviceData = JSON.parse(window.localStorage.getItem(TRIPS_KEY));
          return deviceData;

        } else {

              return $http.get(API_URL + TRIPS_LIST).success(function(response) {

            deviceData = response;
              window.localStorage.setItem(TRIPS_KEY, JSON.stringify(deviceData));
            return deviceData;

          }).error(function(e) {
            return deviceData;
          });
        }
      },
      findById: function(id) {

        var deferred = $q.defer();

          if (window.localStorage.getItem(TRIPS_KEY) !== undefined &&
              window.localStorage.getItem(TRIPS_KEY) !== 'undefined') {
              deviceData = JSON.parse(window.localStorage.getItem(TRIPS_KEY));
        } else {
          deviceData = this.getData();
        }

        var results = deviceData.filter(function(element) {
          var elementId = element.Id;
          return elementId === id;
        });

        deferred.resolve(results);
        return deferred.promise;
      },
      findByName: function(searchKey) {

        var deferred = $q.defer();

          if (window.localStorage.getItem(TRIPS_KEY) !== undefined &&
              window.localStorage.getItem(TRIPS_KEY) !== 'undefined') {
              deviceData = JSON.parse(window.localStorage.getItem(TRIPS_KEY));
        } else {
          deviceData = this.getData();
        }

        var results = deviceData.filter(function(element) {
          return element.Name.toLowerCase().indexOf(searchKey.toLowerCase()) > -1 ||
            element.Model.toLowerCase().indexOf(searchKey.toLowerCase()) > -1;
        });

        deferred.resolve(results);
        return deferred.promise;
      }
    };
    })
.factory('countriesService', function ($http, $q) {

        var deviceData;

        return {
            checkDataUpdates: function () {

                var storageData = [];
                if (window.localStorage.getItem(COUNTRIES_KEY) !== undefined &&
                    window.localStorage.getItem(COUNTRIES_KEY) !== 'undefined')
                    storageData = JSON.parse(window.localStorage.getItem(COUNTRIES_KEY));

                var serverData = [];
                $http.get(API_URL + COUNTRIES_LIST).success(function (response) {

                    serverData = response;

                }).then(function () {

                    if (
                        //(storageData == null || storageData.length == 0) ||
                        (serverData !== null && serverData.length > 0)) {
                        deviceData = serverData;
                        window.localStorage.setItem(COUNTRIES_KEY, JSON.stringify(deviceData));
                    } else
                        deviceData = storageData;

                    return deviceData;
                });

            },
            getData: function () {

                if (window.localStorage.getItem(COUNTRIES_KEY) !== undefined &&
                    window.localStorage.getItem(COUNTRIES_KEY) !== 'undefined') {

                    deviceData = JSON.parse(window.localStorage.getItem(COUNTRIES_KEY));
                    return deviceData;

                } else {

                    return $http.get(API_URL + COUNTRIES_LIST).success(function (response) {

                        deviceData = response;
                        window.localStorage.setItem(COUNTRIES_KEY, JSON.stringify(deviceData));
                        return deviceData;

                    }).error(function (e) {
                        return deviceData;
                    });
                }
            },
            findById: function (id) {

                var deferred = $q.defer();

                if (window.localStorage.getItem(COUNTRIES_KEY) !== undefined &&
                    window.localStorage.getItem(COUNTRIES_KEY) !== 'undefined') {
                    deviceData = JSON.parse(window.localStorage.getItem(COUNTRIES_KEY));
                } else {
                    deviceData = this.getData();
                }

                var results = deviceData.filter(function (element) {
                    var elementId = element.Id;
                    return elementId === id;
                });

                deferred.resolve(results);
                return deferred.promise;
            },
            findByName: function (searchKey) {

                var deferred = $q.defer();

                if (window.localStorage.getItem(COUNTRIES_KEY) !== undefined &&
                    window.localStorage.getItem(COUNTRIES_KEY) !== 'undefined') {
                    deviceData = JSON.parse(window.localStorage.getItem(COUNTRIES_KEY));
                } else {
                    deviceData = this.getData();
                }

                var results = deviceData.filter(function (element) {
                    return element.Name.toLowerCase().indexOf(searchKey.toLowerCase()) > -1 ||
                        element.Model.toLowerCase().indexOf(searchKey.toLowerCase()) > -1;
                });

                deferred.resolve(results);
                return deferred.promise;
            }
        };
    })
.factory('appsettingsService', function ($http, $q) {

    var appsettingsData;

    return {
      checkDataUpdates: function () {

        var storageData = [];
          if (window.localStorage.getItem(SETTINGS_KEY) !== undefined &&
              window.localStorage.getItem(SETTINGS_KEY) !== 'undefined')
              storageData = JSON.parse(window.localStorage.getItem(SETTINGS_KEY));

        var serverData = [];
        $http.get(API_URL + SETTINGS_LIST).success(function (response) {

          serverData = response;

        }).then(function () {

          if (
            //(storageData == null || storageData.length == 0) ||
            (serverData !== null && serverData.length > 0)) {
            appsettingsData = serverData;
            window.localStorage.setItem(SETTINGS_KEY, JSON.stringify(appsettingsData));
          } else
            appsettingsData = storageData;

          return appsettingsData;
        });

      },
      getData: function () {

        if (window.localStorage.getItem(SETTINGS_KEY) !== undefined &&
          window.localStorage.getItem(SETTINGS_KEY) !== 'undefined') {

          appsettingsData = JSON.parse(window.localStorage.getItem(SETTINGS_KEY));
          return appsettingsData;

        } else {

          return $http.get(API_URL + SETTINGS_LIST).success(function (response) {

            appsettingsData = response;
            window.localStorage.setItem(SETTINGS_KEY, JSON.stringify(appsettingsData));
            return appsettingsData;

          }).error(function (e) {
            return appsettingsData;
          });
        }
      },
      findByKey: function (key) {

        var deferred = $q.defer();

        if (window.localStorage.getItem(SETTINGS_KEY) !== undefined &&
            window.localStorage.getItem(SETTINGS_KEY) !== 'undefined' &&
            window.localStorage.getItem(SETTINGS_KEY) !== null) {
          appsettingsData = JSON.parse(window.localStorage.getItem(SETTINGS_KEY));
        } else {
          appsettingsData = this.getData();
        }

        var results = appsettingsData.filter(function (element) {
          var elementKey = element.Key;
          return elementKey === key;
        });

        deferred.resolve(results);
        return deferred.promise;
      }
    };
  })
.factory('logService', function ($http, $q) {
    return {
      add: function(userId, pageUrl, actionType) {
        return $http.get(API_URL + LOG_ADD +userId+'/'+pageUrl+'/'+actionType).success(function(response) {
          return response;
        }).error(function(e) {
          return 0;
        });
      }
    };
  })
.filter('trusted',
  [
    '$sce', function($sce) {
      return function(url) {
        return $sce.trustAsResourceUrl(url);
      };
    }
  ])
.directive('ionSearch', function () {
    return {
      restrict: 'E',
      replace: true,
      scope: {
        getData: '&source',
        model: '=?',
        search: '=?filter'
      },
      link: function (scope, element, attrs) {
        attrs.minLength = attrs.minLength || 0;
        scope.placeholder = attrs.placeholder || '';
        scope.search = { value: '' };

        if (attrs.class)
          element.addClass(attrs.class);
                        
        if (attrs.source) {
          scope.$watch('search.value', function (newValue, oldValue) {
            if (newValue.length >= attrs.minLength) {
              scope.model = scope.getData({ str: newValue });//.then(function (results) {
              //  scope.model = results;
              //});
            } //else {
             // scope.model = [];
           // }
          });
        }

        scope.clearSearch = function () {
          scope.search.value = '';
        };
          
      },
      template: '<label class="item item-input">' +
        '<i class="icon ion-search placeholder-icon"></i>' +
        '<input name="searchKey" id="searchKey" type="search" ng-click="clearSearch()" placeholder="{{placeholder}}" ng-model="search.value"  >' +
        '</label>'
    };
})
.directive('ngCache', function() {

    return {
      restrict: 'A',
      link: function(scope, el, attrs) {

        attrs.$observe('ngSrc', function(src) {

          ImgCache.isCached(src, function(path, success) {
            if (success) {
              ImgCache.useCachedFile(el);
            } else {
              ImgCache.cacheFile(src, function() {
                ImgCache.useCachedFile(el);
              });
            }
          });

        });
      }
    };
  });