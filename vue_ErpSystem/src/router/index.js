import Vue from 'vue'
import VueRouter from 'vue-router'
import notFind from '../components/404.vue'
import Welcome from '../components/Welcom.vue'
import Login from '../components/Login/Login.vue'
import Home from '../components/Home.vue'
// import Role from '../components/Home/Role.vue'
// import Action from '../components/Home/Action.vue'
// import Student from '../components/Home/Student.vue'
// import User from '../components/Home/User.vue'
// import Grade from '../components/Home/Grade.vue'
// import Center from '../components/Home/Center.vue'
// import EditPass from '../components/Home/EditPass.vue'
// import Activity from '../components/Home/Activity.vue'
// import AddActivity from '../components/Home/AddActivity.vue'
Vue.use(VueRouter)

const routes = [{
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
        children: [{
                path: '/welcome',
                component: Welcome,
                meta: { title: '欢迎页' }
            }
            // {
            //   path: '/role',
            //   component: Role,
            //   meta: { title: '角色列表' }
            // },
            // {
            //   path: '/action',
            //   component: Action,
            //   meta: { title: '权限列表' }
            // },
            // {
            //   path: '/student',
            //   component: Student,
            //   meta: { title: '学生列表' }
            // },
            // {
            //   path: '/user',
            //   component: User,
            //   meta: { title: '用户列表' }
            // },
            // {
            //   path: '/grade',
            //   component: Grade,
            //   meta: { title: '班级列表' }
            // },
            // {
            //   path: '/center',
            //   component: Center,
            //   meta: { title: '个人详情' }
            // },
            // {
            //   path: '/editpass',
            //   component: EditPass,
            //   meta: { title: '修改密码' }
            // },
            // {
            //   path: '/activity',
            //   component: Activity,
            //   meta: { title: '活动列表' }
            // },
            // {
            //   path: '/addActivity',
            //   component: AddActivity,
            //   meta: { title: '添加活动' }
            // }
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