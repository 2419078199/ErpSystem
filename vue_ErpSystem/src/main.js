import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import ElementUI from 'element-ui'
import VueI18n from 'vue-i18n'
import { messages } from './components/i18n'
import './assets/css/global.css'
import 'element-ui/lib/theme-chalk/index.css' //默认主题
import './assets/css/icon.css'
import Axios from 'axios'
import './components/directives'
import NProgress from 'nprogress'
import 'nprogress/nprogress.css'
import VueQuillEditor from 'vue-quill-editor'
import 'quill/dist/quill.core.css' // import styles
import 'quill/dist/quill.snow.css' // for snow theme
import 'quill/dist/quill.bubble.css' // for bubble theme

Vue.config.productionTip = false
Axios.defaults.baseURL = 'http://localhost:5000/api/'
Axios.interceptors.request.use((config) => {
  NProgress.start()
  config.headers.Authorization = window.sessionStorage.getItem('token')
  return config
})
Axios.interceptors.response.use(
  (config) => {
    NProgress.done()
    return config
  },
  (error) => {
    console.log(error.response)
    ElementUI.Message.error(error.response.data.msg)
  }
)
Vue.prototype.$axios = Axios
Vue.use(VueI18n)
Vue.use(VueQuillEditor)
Vue.use(ElementUI)
const i18n = new VueI18n({
  locale: 'zh',
  messages
})
Vue.filter('dateFormat', (date) => {
  const dt = new Date(date)
  const y = dt.getFullYear()
  const m = (dt.getMonth() + 1 + '').padStart(2, '0')
  const d = (dt.getDate() + '').padStart(2, '0')
  return `${y}-${m}-${d}`
})
new Vue({
  router,
  store,
  i18n,
  render: (h) => h(App)
}).$mount('#app')
