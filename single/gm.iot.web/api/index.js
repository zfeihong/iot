
var BASEURL = 'http://localhost:8088/';

var service = axios.create({
  baseURL: BASEURL, 
  timeout: 5000 
  // headers: { userId: USER_ID }
});

var login = function(params) {
  return service({
    url: 'api/account/login',
    method: 'get',
    params: params
  });
};

var addBatch = function(url, data, params) {
  return service({
    url: 'api/' + url + '/addBatch',
    method: 'post',
    data: data,
    params: params
  });
};

var get = function(url, params) {
  return service({
    url: 'api/' + url + '/get',
    method: 'get',
    params: params
  });
};

var getList = function(url, params) {
  return service({
    url: 'api/' + url,
    method: 'get',
    params: params
  });
};

var post = function(url, data, params) {
  return service({
    url: 'api/' + url,
    method: 'post',
    data: data,
    params: params
  });
};

var list = function(url, params) {
  return service({
    url: 'api/' + url + '/list',
    method: 'get',
    params: params
  });
};

var add = function(url, data, params) {
  return service({
    url: 'api/' + url + '/add',
    method: 'post',
    data: data,
    params: params
  });
};

var remove = function(url, data, params) {
  return service({
    url: 'api/' + url + '/delete',
    method: 'post',
    data: data,
    params: params
  });
};

var update = function(url, data, params) {
  return service({
    url: 'api/' + url + '/update',
    method: 'post',
    data: data,
    params: params
  });
};

window.SERVER = {
  login: login,
  list: list,
  get: get,
  add: add,
  remove: remove,
  update: update,
  getList: getList,
  addBatch: addBatch,
  post: post
};
