import http from 'k6/http';

export let options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    stages: [
        { duration: '1m', target: 100 },
        { duration: '3m', target: 100 },
        { duration: '1m', target: 200 },
        { duration: '3m', target: 200 },
        { duration: '1m', target: 300 },
        { duration: '3m', target: 300 },
        { duration: '1m', target: 400 },
        { duration: '3m', target: 400 },
        { duration: '5m', target: 0 },
    ]
};



export default function () {
    let token = '';

    const payload = JSON.stringify({
        email: 'client@gmail.com',
        password: 'P@ssw0rd!'
    });
    const resp = http.post('https://localhost:7152/api/Auth', payload, {
        headers: { 'Content-Type': 'application/json' },
    });

    token = resp.json()
    const requestOptions = {
        headers: {
            Authorization: `Bearer ${token}`,
        },
    };
    var r = http.get('https://localhost:7152/api/Application', requestOptions);
    
}
