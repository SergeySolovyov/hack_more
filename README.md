# hack_more

Решение задачи хакатона - команда 15

Алгоритмы защиты:
1. Отправка динамического секретного ключа в каждом запросе
2. Фурье анализ данных акселерометра для подтверждения владельца устройства

Подробное описание
1. Отправка динамического секретного ключа в каждом запросе
Секретный ключ обновляется после каждого запроса на основе предыдущего значения по заданному алгоритму и хэшируется. В ключе зашита информация о url клиента, что усложняет подмену клиента. 
При отправке запроса на апи, на сервере также генерируется секретный ключ и сверяется со значением, отправленным с клиента.
Преимущества:
Динамическая защита
Использование в ключе информации о url, что препятсвует подделке ключа, если будет украден js скрипт алгоритма, т.к. злоумышленник не знает, что ему нужно подменить хост клиента
Возможность использования в качестве gateway для других приложений

2. Фурье анализ данных акселерометра для подтверждения владельца устройства
При регистрации в приложении записывается массив данных с акселерометра (эталонный для данного пользователя, например, за сутки) и сохраняется в бд. При использовании приложения переодически записываются короткие участки данных с акселерометра. Проводится Фурье преобразование над полученными данными. Фурье спектры сравниваются. Если выявляется большое различие м/у спектрами, пользователю отправляется проверка(смс, звонок и тд). Данный подход аможет быть расширен на другие метрики, можно проводить многомерный анализ.
Список литературы:
https://arxiv.org/pdf/1711.04689.pdf Person Recognition using Smartphones’ Accelerometer Data
https://openbooks.itmo.ru/read_ntv/3824/3824.pdf СПЕКТРАЛЬНЫЙ АНАЛИЗ ДАННЫХ С АКСЕЛЕРОМЕТРОВ ДЛЯ ЗАДАЧ ОБНАРУЖЕНИЯ И ИДЕНТИФИКАЦИИ ТРАНСПОРТНЫХ СРЕДСТВ Д.Е. Обертов
