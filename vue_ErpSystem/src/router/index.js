import Vue from 'vue'
import VueRouter from 'vue-router'
import notFind from '../components/404.vue'
import Welcome from '../components/Welcom.vue'
import Login from '../components/Login/Login.vue'
import Home from '../components/Home.vue'
import OrderList from '../components/Order/OrderList.vue'
import Customer from '../components/Customer/Customer.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/login',
    component: Login
  },
  {
    path: '/',
    redirect: '/login'
  },
  {
    path: '/home',
    component: Home,
    redirect: '/welcome',
    children: [
      {
        path: '/welcome',
        component: Welcome,
        meta: { title: '欢迎页' }
      },
      {
        path: '/order',
        component: OrderList,
        meta: { title: '订单列表' }
      },
      {
        path: '/Customer/Index',
        component: Customer,
        meta: { title: '客户信息' }
      }
    ]
  },
  {
    path: '*',
    component: notFind
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})
router.beforeEach((to, from, next) => {
  const token = window.sessionStorage.getItem('token')
  //去login
  if (to.path == '/login') {
    if (token != null) {
      return next('/home')
    }
    return next()
  }
  //不去login
  if (token == null) {
    return next('/login')
  }
  return next()
})
export default router
