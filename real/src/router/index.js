import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Login from "../views/Login.vue";


Vue.use(VueRouter)

const routes = [
  {
    path: "/",
    name: "Login",
    component: Login
  },
  {
    path: "/main",
    component: () => import( "../views/Main.vue"),
    children: [
      {
        path: '',
        name: 'welcome',
        component: () => import('../views/Welcome.vue')
      },
      {
        path: '/oneAllMes',
        component: () => import('../views/RentHouse/OneAllMes.vue')
      },
      {
        path: '/oneSearchMes',
        component: () => import('../views/RentHouse/OneSearchMes.vue')
      },
      {
        path: '/oneSearchMes',
        name: 'oneSearchMes',
        component: () => import('../views/RentHouse/OneSearchMes.vue')
      },
      {
        path: '/oneAddMes',
        name: 'oneAddMes',
        component: () => import('../views/RentHouse/OneAddMes.vue')
      },
      {
        path: '/oneChangeMes',
        name: 'oneChangeMes',
        component: () => import('../views/RentHouse/OneChangeMes.vue')
      },
      {
        path: '/oneDeleteMes',
        name: 'oneDeleteMes',
        component: () => import('../views/RentHouse/OneDeleteMes.vue')
      },
      {
        path: '/oneAddJr',
        name: 'oneAddJr',
        component: () => import('../views/RentHouse/OneAddJr.vue')
      },
      {
        path: '/oneSearchJr',
        name: 'oneSearchJr',
        component: () => import('../views/RentHouse/OneSearchJr.vue')
      },
      {
        path: '/oneDeleteJr',
        name: 'oneDeleteJr',
        component: () => import('../views/RentHouse/OneDeleteJr.vue')
      },
      {
        path: '/twoAllMes',
        name: 'twoAllMes',
        component: () => import('../views/SellHouse/TwoAllMes.vue')
      },
      {
        path: '/twoSearchMes',
        name: 'twoSearchMes',
        component: () => import('../views/SellHouse/TwoSearchMes.vue')
      },
      {
        path: '/twoAddMes',
        name: 'twoAddMes',
        component: () => import('../views/SellHouse/TwoAddMes.vue')
      },
      {
        path: '/twoDeleteMes',
        name: 'twoDeleteMes',
        component: () => import('../views/SellHouse/TwoDeleteMes.vue')
      },
      {
        path: '/threeAllMes',
        name: 'threeAllMes',
        component: () => import('../views/BegRentHouse/ThreeAllMes.vue')
      },
      {
        path: '/threeRecordMes',
        name: 'threeRecordMes',
        component: () => import('../views/BegRentHouse/ThreeAddMes.vue')
      },
      {
        path: '/threeDeleteMes',
        name: 'threeDeleteMes',
        component: () => import('../views/BegRentHouse/ThreeDeleteMes.vue')
      },
      {
        path: '/fourAllMes',
        name: 'fourAllMes',
        component: () => import('../views/BegBuyHouse/FourAllMes.vue')
      },
      {
        path: '/fourRecordMes',
        name: 'fourRecordMes',
        component: () => import('../views/BegBuyHouse/FourAddMes.vue')
      },
      {
        path: '/fourChangeMes',
        name: 'fourChangeMes',
        component: () => import('../views/BegBuyHouse/FourDeleteMes.vue')
      },
    ]
  },

  // {
  //   path: '/oneAllMes',
  //   name: 'oneAllMes',
  //   component: () => import('../views/RentHouse/OneAllMes.vue')
  // },
]

const router = new VueRouter({
  mode: 'history',
  routes
})
const originalPush = VueRouter.prototype.push
  VueRouter.prototype.push = function push(location) {
  return originalPush.call(this, location).catch(err => err)
}
export default router
