import Vue from 'vue'
import VueRouter from 'vue-router'
import notFind from '../components/404.vue'
import Welcome from '../components/Welcom.vue'
import Login from '../components/Login/Login.vue'
import Home from '../components/Home.vue'
import Suppliers from '../components/Suppliers/SupplierList.vue'
import ProductPlan from '../components/Product/Plan.vue'
import ProductPicking from '../components/Product/Picking.vue'
import ProductProductPr from '../components/Product/ProductPr.vue'
import ProductSlOrderPrTask from '../components/Product/SlOrderPrTask.vue'
import WarehouseProductWH from '../components/PrWarehouse/ProductWH.vue'
import WarehouseProductInWH from '../components/PrWarehouse/ProductInWH.vue'
import WarehouseProductInWHMng from '../components/PrWarehouse/ProductInWHMng.vue'
import WarehouseProductOutWH from '../components/PrWarehouse/ProductOutWH.vue'
import WarehouseProductOutWHMng from '../components/PrWarehouse/ProductOutWHMng.vue'
// import Role from '../components/Home/Role.vue'
// import Action from '../components/Home/Action.vue'
// import Student from '../components/Home/Student.vue'
// import User from '../components/Home/User.vue'
// import Grade from '../components/Home/Grade.vue'
// import Center from '../components/Home/Center.vue'
// import EditPass from '../components/Home/EditPass.vue'
// import Activity from '../components/Home/Activity.vue'
// import AddActivity from '../components/Home/AddActivity.vue'

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
        path: '/Suppliers/Index',
        component: Suppliers,
        meta: { title: '供应商信息' }
      },
      {
        path: '/Plan',
        component: ProductPlan,
        meta: { title: '生产计划管理' }
      },
      {
        path: '/Picking',
        component: ProductPicking,
        meta: { title: '领料管理' }
      },
      {
        path: '/Product',
        component: ProductProductPr,
        meta: { title: '产品生产' }
      },
      {
        path: '/SlOrderPrTask',
        component: ProductSlOrderPrTask,
        meta: { title: '订单查询' }
      },
      {
        path: '/ProductWH',
        component: WarehouseProductWH,
        meta: { title: '库存管理' }
      },
      {
        path: '/ProductInWH',
        component: WarehouseProductInWH,
        meta: { title: '添加入库单' }
      },
      {
        path: '/ProductInWHMng',
        component: WarehouseProductInWHMng,
        meta: { title: '入库单管理' }
      },
      {
        path: '/ProductOutWH',
        component: WarehouseProductOutWH,
        meta: { title: '添加出库单' }
      },
      {
        path: '/ProductOutWHMng',
        component: WarehouseProductOutWHMng,
        meta: { title: '出库单管理' }
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
