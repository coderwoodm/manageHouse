import Vue from 'vue'
import App from './App.vue'
import router from './router/index'
import Antd from 'ant-design-vue';
import 'ant-design-vue/dist/antd.css';
import ajaxs from "./api/index.js"

Vue.prototype.$http = ajaxs;
Vue.config.productionTip = false;
Vue.use(Antd);
Vue.config.productionTip = false


new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
