import request from '../utils/request'

const dataService = {
    async getAllRestaurants() {
        return request({
            url: '/api/restaurants',
            method: 'get'
        });
    },

    async getAllRestaurantsBySearchKey(keyWord) {
        return request({
            url: `/api/restaurants/${keyWord}`,
            method: 'get'
        });
    },

    async CreateOrder(data) {
        return request({
            url: '/api/orders',
            method: 'post',
            data
        });
    },
}

export default dataService;