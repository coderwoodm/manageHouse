import axios from "axios";

const ajaxs = axios.create({

  baseURL: "http://localhost:31203/Home/",
  timeout: 3000
})

ajaxs.interceptors.request.use(function (confing) {
  return confing;
},function (erro) {
  return Promise.reject(erro)
})

ajaxs.interceptors.response.use(function (confing) {
  return confing;
},function (erro) {
  return Promise.reject(erro)
})

export default ajaxs