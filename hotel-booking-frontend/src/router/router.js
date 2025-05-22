import { createRouter, createWebHistory } from 'vue-router'
import RoomList from '../components/RoomList'

const routes = [
    {
        path: '/rooms/:hotelId',
        name: 'RoomList',
        component: RoomList,
        props: true
    }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
